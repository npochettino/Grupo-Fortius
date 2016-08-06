using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Export
{
    public static class ExcelManager
    {
        #region Constantes

        private const string fileExtension = ".xlsx";

        private const string IEntityInterface = "IEntityBase";

        public const string ContentTypeForExcel = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        #endregion

        #region Metodos de exportacion
        /// <summary>
        /// Crea un excel a partir de una lista de objetos, y lo guarda en el directorio raiz de la applicacion
        /// </summary>
        /// <typeparam name="T">Tipo de objeto de la lista</typeparam>
        /// <param name="objects">Lista de objetos, cuya informacion sera volcada en el excel</param>
        /// <returns></returns>
        public static string CreateExcel<T>(List<T> objects)
        {
            return CreateExcel(objects, AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// Crea un excel a partir de una lista de objetos
        /// </summary>
        /// <typeparam name="T">Tipo de objeto de la lista</typeparam>
        /// <param name="objects">Lista de objetos, cuya informacion sera volcada en el excel</param>
        /// <param name="path">Directorio donde se guardara el excel</param>
        /// <returns></returns>
        public static string CreateExcel<T>(List<T> objects, string path)
        {
            var defaultFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_Excel";
            return CreateExcel(objects, path, DateTime.Now.ToString("yyyyMMddhhmmss") + defaultFileName);
        }

        /// <summary>
        /// Crea un excel a partir de una lista de objetos
        /// </summary>
        /// <typeparam name="T">Tipo de objeto de la lista</typeparam>
        /// <param name="objects">Lista de objetos, cuya informacion sera volcada en el excel</param>
        /// <param name="path">Directorio donde se guardara el excel</param>
        /// <param name="fileName">nombre del excel</param>
        /// <returns></returns>
        public static string CreateExcel<T>(List<T> objects, string path, string fileName)
        {
            var excelPath = string.Empty;

            excelPath = path + fileName + fileExtension;

            var fileInfo = new System.IO.FileInfo(excelPath);

            using (ExcelPackage excel = new ExcelPackage(fileInfo))
            {
                var sheet = excel.Workbook.Worksheets.Add(objects.GetType().GetGenericArguments()[0].Name);

                var properties = typeof(T).GetProperties();

                var expArra = objects.ToArray();

                CreateHeaders(sheet, expArra, false, string.Empty);
                CreateBody(sheet, expArra, false);

                excel.SaveAs(fileInfo);
            }
            return excelPath;
        }

        /// <summary>
        /// Exporta un datatable a Excel (la carpeta de destino es el directorio base de la applicacion)
        /// </summary>
        /// <param name="dt">tabla con la lista de objetos (paies)</param>
        /// <returns></returns>
        public static string ExportDataTableToExcel(DataTable dt)
        {
            return ExportDataTableToExcel(dt, AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// Exporta un datatable a Excel
        /// </summary>
        /// <param name="dt">tabla con la lista de objetos (paies)</param>
        /// <param name="path">Carpeta de destino</param>
        /// <returns></returns>
        public static string ExportDataTableToExcel(DataTable dt, string path)
        {
            var defaultFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_Excel";
            return ExportDataTableToExcel(dt, path, defaultFileName);
        }

        /// <summary>
        /// Exporta un datatable a Excel
        /// </summary>
        /// <param name="dt">tabla con la lista de objetos (paies)</param>
        /// <param name="path">Carpeta de destino</param>
        /// <param name="fileName">nombre del archivo</param>
        /// <returns></returns>
        public static string ExportDataTableToExcel(DataTable dt, string path, string fileName)
        {
            var excelPath = string.Empty;

            excelPath = path + fileName + fileExtension;

            var fileInfo = new System.IO.FileInfo(excelPath);

            using (ExcelPackage excel = new ExcelPackage(fileInfo))
            {
                var sheet = excel.Workbook.Worksheets.Add(dt.TableName);

                sheet.Cells[1, 1].LoadFromDataTable(dt, true);

                //Formatea las celdas que contienen fechas
                var date = DateTime.Now;
                //obtiene las celdas parceables a fechas
                var datesCells = sheet.Cells.Where(c => DateTime.TryParse(c.Value.ToString(), out date));

                foreach (var dateCell in datesCells)
                {
                    dateCell.Style.Numberformat.Format = "mm-dd-yy";

                    dateCell.AutoFitColumns(200.0);
                }

                foreach (var cell in sheet.Cells.Where(c => c.Start.Row == 1))
                {
                    cell.Style.Font.Bold = true;
                    cell.AutoFitColumns();
                }

                sheet.Cells.AutoFitColumns();

                excel.SaveAs(fileInfo);
            }
            return excelPath;
        }

        /// <summary>
        /// Crea los headers para el excel
        /// </summary>
        /// <typeparam name="T">tipo de entidad</typeparam>
        /// <param name="sheet">hoja del excel</param>
        /// <param name="expArra">array de entidades</param>
        /// <param name="inner">si es con nivel de anidacion (para propiedades de navegacion)</param>
        private static void CreateHeaders<T>(ExcelWorksheet sheet, T[] expArra, bool inner, string entityName)
        {
            var allProperties = typeof(T).GetProperties().OrderBy(o => o.PropertyType.GetInterface(IEntityInterface));

            if (inner)
            {
                if (expArra[0] == null)
                    return;
                //en un nivel de anidacion, se obtienen las propiedades de esta manera
                allProperties = expArra[0].GetType().GetProperties().OrderBy(o => o.PropertyType.GetInterface(IEntityInterface));
            }

            //propiedades que no son de navegacion
            var nonNavProperties = allProperties.Where(p => p.PropertyType.GetInterface(IEntityInterface) == null).ToArray();

            if (!inner)
            {
                for (int i = 0; i < nonNavProperties.Length; i++)
                {
                    sheet.Cells[1, i + 1].Value = nonNavProperties[i].Name;

                    sheet.Cells[1, i + 1].Style.Font.Bold = true;

                    sheet.Cells[1, i + 1].AutoFitColumns();
                }
            }
            else
            {

                for (int i = 0; i < nonNavProperties.Length; i++)
                {
                    var length = sheet.Cells.Count();
                    //en un nivel de anidacion, se concatena el nombre de la clase y su propiedad, ej . PaisNombre
                    sheet.Cells[1, length + 1].Value = entityName + nonNavProperties[i].Name;

                    sheet.Cells[1, length + 1].Style.Font.Bold = true;

                    sheet.Cells[1, length + 1].AutoFitColumns();
                }
            }

            var navProperties = allProperties.Where(p => p.PropertyType.GetInterface(IEntityInterface) != null);
            if (navProperties.Count() > 0)
            {
                foreach (var navProperty in navProperties)
                {
                    object val = null;
                    foreach (var item in expArra)
                    {
                        val = navProperty.GetValue(item);
                        if (val != null)
                            break;
                    }
                    //crea headers para propiedades de navegacion, recursivamente
                    CreateHeaders(sheet, new[] { navProperty.GetValue(expArra[0]) }, true, navProperty.Name);
                }
            }
        }

        /// <summary>
        /// Crea el cuerpo del excel
        /// </summary>
        /// <typeparam name="T">tipo de entidad</typeparam>
        /// <param name="sheet">hoja del excel</param>
        /// <param name="expArra">el array de entidades</param>
        /// <param name="inner">nivel de anidacion para propiedades de navegacion</param>
        private static void CreateBody<T>(ExcelWorksheet sheet, T[] expArra, bool inner)
        {
            var cells = sheet.Cells.ToList();
            for (int i = 0; i < expArra.Length; i++)
            {
                foreach (var cell in cells)
                {
                    var cellName = cell.Value.ToString();
                    var property = expArra[i].GetType().GetProperty(cellName);
                    if (property != null)
                    {
                        var value = property.GetValue(expArra[i]);

                        //obtiene la columna ej -> A,B,C etc
                        var column = cell.Address.Replace(cell.Start.Row.ToString(), string.Empty);
                        var lastColumnIndex = sheet.Cells.Where(c => c.Address.Equals(column + c.Start.Row.ToString())).ToList().Count;

                        sheet.Cells[lastColumnIndex + 1, cell.Start.Column].Value = ValueFormat(value);
                    }
                    else
                    {
                        //splitea por mayusculas , ej. -> PaisNombre -> new[] {"Pais","Nombre"} para obtener las propiedades de navegacion y sus valores
                        var res = System.Text.RegularExpressions.Regex.Replace(cellName, "([a-z])([A-Z])", "$1 $2").Split(' ');
                        var entityName = res.Count() > 2 ? res[0] + res[1] : res.FirstOrDefault();
                        entityName = entityName.Replace("Entity", string.Empty);
                        //obtiene la propiedad de navegacion, que es una entidad en si mismo
                        var navProperty = expArra[i].GetType().GetProperty(entityName);
                        var navEntity = navProperty.GetValue(expArra[i]);

                        //obtiene la propiedad que se corresponde con la celda
                        var innerProperty = navEntity.GetType().GetProperty(res.LastOrDefault());

                        if (innerProperty == null)
                            innerProperty = navEntity.GetType().GetProperty("EntityID");

                        var value = innerProperty.GetValue(navEntity);

                        //obtiene la columna ej -> A,B,C etc
                        var column = cell.Address.Replace(cell.Start.Row.ToString(), string.Empty);
                        var lastColumnIndex = sheet.Cells.Where(c => c.Address.Contains(column)).ToList().Count;

                        sheet.Cells[lastColumnIndex + 1, cell.Start.Column].Value = ValueFormat(value);
                    }
                }
            }

        }

        #region Deprecated

        /// <summary>
        /// Formatea los headers -- Deprecado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="expArra"></param>
        /// <param name="properties"></param>
        /// <param name="isNavigationProperty"></param>
        private static void FormatHeaders<T>(ExcelWorksheet sheet, T[] expArra, PropertyInfo[] properties, bool isNavigationProperty)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType.GetInterface(IEntityInterface) != null)
                {
                    if (properties[i].GetValue(expArra[0]) == null)
                        continue;

                    FormatNavigationHeaders(sheet, new[] { properties[i].GetValue(expArra[0]) }, properties[i].GetValue(expArra[0]).GetType().GetProperties(), true);
                    continue;
                }

                sheet.Cells[1, i + 1].Value = properties[i].Name;

                sheet.Cells[1, i + 1].Style.Font.Bold = true;

            }
        }

        /// <summary>
        /// formatea los headers de las propiedades de navegacion de la entidad -- Deprecado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="expArra"></param>
        /// <param name="properties"></param>
        /// <param name="isNavigationProperty"></param>
        private static void FormatNavigationHeaders<T>(ExcelWorksheet sheet, T[] expArra, PropertyInfo[] properties, bool isNavigationProperty)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                var length = sheet.Cells.Count();

                sheet.Cells[1, length + 1].Value = expArra[0].GetType().Name + properties[i].Name;

                sheet.Cells[1, length + 1].Style.Font.Bold = true;
            }
        }

        /// <summary>
        /// vuelca los datos de la lista de objetos -- Deprecado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="expArra"></param>
        /// <param name="properties"></param>
        /// <param name="isNavigationProperty"></param>
        private static void FormatBody<T>(ExcelWorksheet sheet, T[] expArra, PropertyInfo[] properties, bool isNavigationProperty)
        {
            var lenght = sheet.Cells.Where(c => c.Address.Contains("1")).Count();
            for (int i = 0; i < expArra.Length; i++)
            {
                bool navigationFilled = false;
                for (int col = 0; col < lenght; col++)
                {
                    var cellName = sheet.Cells[1, col + 1].Value;
                    var cell = sheet.Cells[1, col + 1];
                    var property = properties.FirstOrDefault(p => p.Name.Equals(cellName));
                    if (property != null)
                    {
                        var value = property.GetValue(expArra[i]);
                        sheet.Cells[i + 2, col + 1].Value = ValueFormat(value);
                    }

                    if (property == null && !navigationFilled)
                    {
                        var navProperties = properties.Where(p => p.PropertyType.GetInterface(IEntityInterface) != null).Select(p => p.Name);
                        foreach (var navProp in navProperties)
                        {
                            property = properties.FirstOrDefault(p => p.Name.Equals(navProp));

                            if (property.GetValue(expArra[0]) == null)
                                continue;

                            FormatNavigationPropertiesBody(sheet, new[] { property.GetValue(expArra[i]) }, property.GetValue(expArra[0]).GetType().GetProperties(), true);
                            navigationFilled = true;
                        }
                    }

                }

            }
        }

        /// <summary>
        /// vuelca los datos de las propiedades de navegacion de la lista de objetos -- Deprecado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="expArra"></param>
        /// <param name="properties"></param>
        /// <param name="isNavigationProperty"></param>
        private static void FormatNavigationPropertiesBody<T>(ExcelWorksheet sheet, T[] expArra, PropertyInfo[] properties, bool isNavigationProperty)
        {
            for (int i = 0; i < expArra.Length; i++)
            {
                var navPropertyName = expArra[0].GetType().Name;
                var navCells = sheet.Cells.Where(c => c.Value.ToString().Contains(navPropertyName)).ToList();
                foreach (var cell in navCells)
                {
                    var cellName = cell.Value.ToString().Replace(navPropertyName, string.Empty);
                    var property = properties.FirstOrDefault(p => p.Name.Equals(cellName));
                    if (property != null)
                    {
                        var column = cell.Address.Replace(cell.Start.Row.ToString(), string.Empty);
                        var lastColumnIndex = sheet.Cells.Where(c => c.Address.Contains(column)).ToList().Count;
                        var value = property.GetValue(expArra[i]);
                        sheet.Cells[lastColumnIndex + 1, cell.Start.Column].Value = ValueFormat(value);
                    }
                }

            }
        }

        #endregion

        #region Formateo de celdas

        private static string CellFormat(object value)
        {
            if (value is DateTime)
                return "d-m-yyyy";

            if (value is bool)
                return "@";

            return string.Empty;
        }

        private static object ValueFormat(object value)
        {
            if (value == null)
                return string.Empty;

            if (value is int)
                return value;

            return value.ToString();
        }
        #endregion

        #endregion
    }
}
