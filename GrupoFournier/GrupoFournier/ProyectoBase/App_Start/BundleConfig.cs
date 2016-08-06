using System.Web;
using System.Web.Optimization;

namespace PresentacionGrupoFournier
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Jquery, validaciones y Boostrap

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*",
                    "~/Scripts/jquery.validate.unobtrusive*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-select.js",
                        "~/Scripts/bootbox.min.js",
                        "~/Scripts/validator.js",
                       "~/Scripts/multiselect/multiselect.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/bundles/Content/css").Include(
                      "~/Content/bootstrap-select.css")
                      .Include("~/Content/bootstrap.css", new CssRewriteUrlTransform()));

            #endregion

            #region Tema AdminLTE

            // -- Bundle de estilos para el tema del sitio
            bundles.Add(new StyleBundle("~/bundles/Content/TemaAdminLTE").Include(
                      "~/Content/TemaAdminLTE/AdminLTE.min.css",
                      "~/Content/TemaAdminLTE/daterangepicker-bs3.css",
                      "~/Content/TemaAdminLTE/skins/_all-skins.min.css",
                      "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                      "~/Content/PresentationStyles.css"
                      )
                      .Include("~/Content/plugins/colorpicker/bootstrap-colorpicker.css", new CssRewriteUrlTransform())
                      .Include("~/Content/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform()));

            // -- Bundle de scripts para el tema del sitio
            bundles.Add(new ScriptBundle("~/bundles/Scripts/TemaAdminLTE").Include(
                      "~/Scripts/plugins/jquery-ui/jquery-ui.min.js",
                      "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js",
                      "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                      "~/Scripts/plugins/colorpicker/bootstrap-colorpicker.js",
                      "~/Scripts/TemaAdminLTE/app.min.js",
                      "~/Scripts/TemaAdminLTE/moment.min.js",
                      "~/Scripts/PresentationScripts.js",
                      "~/Scripts/Fwk.js"
                      ));

            #endregion

            #region Grillas

            // -- Bundle de estilos para dataTables de Jquery, se usa en las grillas en conjunto con Grid.MVC
            bundles.Add(new StyleBundle("~/bundles/Content/dataTables").Include(
                      "~/Content/plugins/dataTables/dataTables.bootstrap.css",
                      "~/Content/plugins/dataTables/dataTables.custom.css"
                      ));

            // -- Bundle de scripts para dataTables de Jquery, se usa en las grillas en conjunto con Grid.MVC
            bundles.Add(new ScriptBundle("~/bundles/Scripts/dataTables").Include(
                      "~/Scripts/plugins/dataTables/jquery.dataTables.js",
                      "~/Scripts/plugins/dataTables/dataTables.bootstrap.js",
                      "~/Scripts/plugins/dataTables/dataTables.lang.es.js",
                      "~/Scripts/plugins/dataTables/dataTables.custom.js"
                      ));

            // -- Bundle de estilos para Grid.MVC, se usa en las grillas en conjunto con dataTables
            bundles.Add(new StyleBundle("~/bundles/Content/GridMVC").Include(
                      "~/Content/Gridmvc.css"
                      ));

            // -- Bundle de scripts para Grid.MVC, se usa en las grillas en conjunto con dataTables
            bundles.Add(new ScriptBundle("~/bundles/Scripts/GridMVC").Include(
                      "~/Scripts/gridmvc.js",
                      "~/Scripts/gridmvc.lang.es.js"));

            #endregion

            #region TreeView

            // -- Bundle de scripts para treeView
            bundles.Add(new ScriptBundle("~/bundles/Scripts/TreeView").Include(
                      "~/Scripts/plugins/tree/jquery.aciPlugin.min.js",
                      "~/Scripts/plugins/tree/jquery.aciSortable.min.js",
                      "~/Scripts/plugins/tree/jquery.aciTree.min.js",
                      "~/Scripts/plugins/tree/jquery.aciTree.selectable.js",
                      "~/Scripts/plugins/tree/tree.js"));

            // -- Bundle de estilos para treeView
            bundles.Add(new StyleBundle("~/bundles/Content/TreeView").Include(
                      "~/Content/plugins/tree/tree.css",
                      "~/Content/plugins/tree/bootsnipp.min.css").Include("~/Content/plugins/tree/aciTree.css", new CssRewriteUrlTransform()));

            #endregion

            #region PNotify - Handler de Alertas

            // -- Bundle para las notificaciones
            bundles.Add(new StyleBundle("~/bundles/Content/PNotifyStyle").Include("~/Content/pnotify.custom*"));
            bundles.Add(new ScriptBundle("~/bundles/PNotify").Include("~/Scripts/pnotify.custom*"));

            #endregion

            #region JQuery easy overlay

            // -- Bundle para bloquear y desbloquear pantalla
            bundles.Add(new ScriptBundle("~/bundles/Scripts/JQuery-easy-overlay").Include("~/Scripts/plugins/jquery-easy-overlay/jquery.easy-overlay.js"));

            // -- Bundle de scripts para controlBusqueda
            bundles.Add(new ScriptBundle("~/bundles/Scripts/ControlBusqueda").Include(
                      "~/Scripts/plugins/controlBusqueda/controlBusqueda.js"));

            // -- Bundle de scripts para variables de controlBusqueda
            bundles.Add(new ScriptBundle("~/bundles/Scripts/VariablesControlBusqueda").Include(
                      "~/Scripts/plugins/controlBusqueda/variablesControlBusqueda.js"));


            // -- Bundle de estilos select2(seleccion multiple)
            bundles.Add(new StyleBundle("~/bundles/Content/Select2").Include(
                      "~/Content/plugins/select2/select2.min.css"
                      ));

            // -- Bundle de scripts select2(seleccion multiple)
            bundles.Add(new ScriptBundle("~/bundles/Scripts/Select2").Include(
                      "~/Scripts/plugins/select2/select2.full.min.js"));
            #endregion

            #region InputMask

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            "~/Scripts/jquery.inputmask/inputmask.js",
            "~/Scripts/jquery.inputmask/jquery.inputmask.js",
            "~/Scripts/jquery.inputmask/inputmask.extensions.js",
            "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
            "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js"));

            // -- Bundle de script para control de input-icon
            bundles.Add(new ScriptBundle("~/bundles/Scripts/controlInputIcon").Include(
                      "~/Scripts/plugins/controllnputIcon/inputIcon.js"));

            #endregion  

            #region ReproductorCursos

            // -- Bundle de scripts para reproductor de cursos
            bundles.Add(new ScriptBundle("~/bundles/Scripts/ReproductorCursos").Include(
                      "~/Scripts/plugins/reproductorCursos/APIConstants.js",
                      "~/Scripts/plugins/reproductorCursos/Configuration.js",
                      "~/Scripts/plugins/reproductorCursos/UtilityFunctions.js",
                      "~/Scripts/plugins/reproductorCursos/SCORM2004Functions.js",
                      "~/Scripts/plugins/reproductorCursos/SCORMFunctions.js",
                      "~/Scripts/plugins/reproductorCursos/AICCFunctions.js",
                      "~/Scripts/plugins/reproductorCursos/NONEFunctions.js",
                      "~/Scripts/plugins/reproductorCursos/LMSAPI.js",
                      "~/Scripts/plugins/reproductorCursos/API.js"));

            #endregion

            #region Bootstrap DateTime picker

            // -- Bundle de script para datetime picker
            bundles.Add(new ScriptBundle("~/bundles/Scripts/bootstrap-datetime-picker").Include(
                "~/Scripts/plugins/datepicker/bootstrap-datepicker.js",
                "~/Scripts/plugins/datepicker/bootstrap-datepicker.es.min.js",
                "~/Scripts/plugins/datepicker/bootstrap-datetimepicker.js",
                "~/Scripts/plugins/datepicker/bootstrap-datetimepicker-custom.js"));

            // -- Bundle de style para datetime picker
            bundles.Add(new StyleBundle("~/bundles/Content/bootstrap-datetime-picker").Include(
                "~/Content/plugins/datepicker/datepicker3.css",
                "~/Content/plugins/datepicker/datepicker.custom.css",
                "~/Content/plugins/datepicker/bootstrap-datetimepicker.css"));

            // -- Bundle de script para daterange picker
            bundles.Add(new ScriptBundle("~/bundles/Scripts/daterangepicker").Include(
                "~/Scripts/plugins/daterangepicker/daterangepicker.js",
                "~/Scripts/plugins/daterangepicker/daterangepicker.custom.js"));

            // -- Bundle de style para daterange picker
            bundles.Add(new StyleBundle("~/bundles/Content/daterangepicker").Include(
                "~/Content/plugins/daterangepicker/daterangepicker-bs3.css",
                "~/Content/plugins/daterangepicker/daterangepicker.custom.css",
                "~/Content/plugins/daterangepicker/daterangepicker.css"));

            #endregion
        }
    }
}
