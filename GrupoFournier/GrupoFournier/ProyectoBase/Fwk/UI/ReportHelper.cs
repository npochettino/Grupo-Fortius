using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBase.Fwk.UI
{
    /// <summary>
    /// Clase helper para el manejo de: Report Viewer.
    /// </summary>
    public static class ReportHelper
    {

        /// <summary>
        /// Instancia un ReportViewer y retorna el array de bytes.
        /// En presentacion, crear ActionResult que envie el reporte a la view: return File(objBytes, strMime)
        /// </summary>
        /// <param name="reportPath">Path del .RDLC (Sin incluir extension)</param>
        /// <param name="DataSource">DataSet</param>
        /// <param name="DataSetName">Nombre del DataSet</param>
        /// <param name="strMime">Enviar string vacio</param>
        /// <returns>byte[]</returns>
        public static byte[] Create(string reportPath, object DataSource, string DataSetName, ref string strMime)
        {
            // -- Instanciamos y configuramos el Report Viewer.
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            //reportViewer.LocalReport.ReportPath = reportPath;
            reportViewer.LocalReport.ReportPath = reportPath;
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(DataSetName, DataSource));

            // -- Ejecutamos metodo que nos retorna bytes.
            string strEncoding = string.Empty;
            string strExtension = string.Empty;
            Warning[] objWarnings;
            string[] objStrmIds;
            byte[] objBytes;
            objBytes = reportViewer.LocalReport.Render("PDF", null, out strMime, out strEncoding, out strExtension, out objStrmIds, out objWarnings);

            // -- Retornamos los bytes.
            return objBytes;
        }

        /// <summary>
        /// Instancia un ReportViewer y retorna el array de bytes.
        /// En presentacion, crear ActionResult que envie el reporte a la view: return File(objBytes, strMime)
        /// </summary>
        /// <param name="reportPath">Path del .RDLC (Sin incluir extension)</param>
        /// <param name="DataSource">DataSet</param>
        /// <param name="parameters">Parametros del Reporte</param>
        /// <param name="DataSetName">Nombre del DataSet</param>
        /// <param name="strMime">Enviar string vacio</param>
        /// <returns>byte[]</returns>
        public static byte[] Create(string reportPath, object DataSource, List<ReportParameter> parameters, string DataSetName, ref string strMime)
        {
            // -- Instanciamos y configuramos el Report Viewer.
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.EnableExternalImages = true;
            reportViewer.LocalReport.ReportPath = reportPath;
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(DataSetName, DataSource));
            reportViewer.LocalReport.SetParameters(parameters);

            // -- Ejecutamos metodo que nos retorna bytes.
            string strEncoding = string.Empty;
            string strExtension = string.Empty;
            Warning[] objWarnings;
            string[] objStrmIds;
            byte[] objBytes;
            objBytes = reportViewer.LocalReport.Render("PDF", null, out strMime, out strEncoding, out strExtension, out objStrmIds, out objWarnings);

            // -- Retornamos los bytes.
            return objBytes;
        }

    }
}