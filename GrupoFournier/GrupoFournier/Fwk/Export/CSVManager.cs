using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Export
{
    /// <summary>
    /// Clase para generar CSV en base objects.
    /// </summary>
    public class CSVManager
    {

        #region Constantes

        private const String SEPARATOR_CHAR = ";";

        #endregion

        /// <summary>
        /// /// Genera un CSV en base a un objeto. 
        /// El objeto, debe tener declara en sus propiedades, el atributo "CsvColumnName".
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="csvDataObjects">Lista de objetos</param>
        /// <returns>String (CSV)</returns>
        public string GetCsv<T>(List<T> csvDataObjects)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            var sb = new StringBuilder();
            sb.AppendLine(GetCsvHeaderSorted(propertyInfos));
            csvDataObjects.ForEach(d => sb.AppendLine(GetCsvDataRowSorted(d, propertyInfos)));
            return sb.ToString();
        }

        #region Private Methods

        private string GetCsvDataRowSorted<T>(T csvDataObject, PropertyInfo[] propertyInfos)
        {
            IEnumerable<string> valuesSorted = propertyInfos
                .Select(x => new
                {
                    Value = x.GetValue(csvDataObject, null),
                    Attribute = (CsvColumnNameAttribute)Attribute.GetCustomAttribute(x, typeof(CsvColumnNameAttribute), false)
                })
                .Where(x => x.Attribute != null && x.Attribute.Export)
                .OrderBy(x => x.Attribute.Order)
                .Select(x => GetPropertyValueAsString(x.Value));
            return String.Join(SEPARATOR_CHAR, valuesSorted);
        }

        private string GetCsvHeaderSorted(PropertyInfo[] propertyInfos)
        {
            IEnumerable<string> headersSorted = propertyInfos
                .Select(x => (CsvColumnNameAttribute)Attribute.GetCustomAttribute(x, typeof(CsvColumnNameAttribute), false))
                .Where(x => x != null && x.Export)
                .OrderBy(x => x.Order)
                .Select(x => x.Name);
            return String.Join(SEPARATOR_CHAR, headersSorted);
        }

        private string GetPropertyValueAsString(object propertyValue)
        {
            string propertyValueString;

            if (propertyValue == null)
                propertyValueString = "";
            else if (propertyValue is DateTime)
                propertyValueString = ((DateTime)propertyValue).ToString("dd MMM yyyy");
            else if (propertyValue is int)
                propertyValueString = propertyValue.ToString();
            else if (propertyValue is float)
                propertyValueString = ((float)propertyValue).ToString("#.####");
            else if (propertyValue is double)
                propertyValueString = ((double)propertyValue).ToString("#.####");
            else if (propertyValue is decimal)
                propertyValueString = ((decimal)propertyValue).ToString("#.####");
            else // treat as a string
                propertyValueString = @"""" + propertyValue.ToString().Replace(@"""", @"""""") + @"""";

            return propertyValueString;
        }

        #endregion
    }

    /// <summary>
    /// Clase que representa el atributo a agregar a las propiedades para que funcione el conversor.
    /// </summary>
    public class CsvColumnNameAttribute : Attribute
    {
        #region Properties

        public bool Export { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }

        #endregion

        #region Ctor

        public CsvColumnNameAttribute()
        {
            Export = true;
            Order = int.MaxValue;
        }

        #endregion
    }
}
