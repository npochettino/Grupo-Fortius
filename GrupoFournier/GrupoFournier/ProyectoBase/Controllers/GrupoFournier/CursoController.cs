using Cross.Common;
using Entities;
using Fwk.Session;
using Logic;
using ProyectoBase.Fwk.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.GrupoFournier;

namespace PresentacionGrupoFournier.Controllers
{
    public class CursoController : BaseController<Curso, CursoLogic>
    {
        #region CONST

        private const string ImagenesPath = "~/Imagenes/ImagenesCursos/";

        // -- El formato sería "curso" + curso.EntityID + extension
        // -- Ejemplo "curso1.jpg"
        private const string ImagenCursoPath = "curso{0}{1}";

        #endregion

        #region Logics

        CursoUsuarioLogic cursoUsuarioLogic;
        CursoUsuarioLogic CursoUsuarioLogic
        {
            get
            {
                if (cursoUsuarioLogic == null)
                {
                    cursoUsuarioLogic = new CursoUsuarioLogic();
                }
                return cursoUsuarioLogic;
            }
        }

        #endregion
        // GET: Curso
        /// <summary>
        /// Vista de lista de cursos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            List<Curso> cursos = new List<Curso>();

            //Si el usuario es administrador del sitio o administrador recupero todos los cursos
            if (usuarioLogueado.Rol.EntityID == Convert.ToInt64(Global.Roles.ADMINISTRADOR) || usuarioLogueado.Rol.EntityID == Convert.ToInt64(Global.Roles.ADMINISTRADOR_SITIO))
            {
                cursos = logic.GetAllActivos();
            }
            else //Sino recupero los que se crearon en su empresa
            {
                cursos = logic.GetByCreadoEmpresa(usuarioLogueado.Empresa.EntityID);
            }

            return View(cursos);
        }

        /// <summary>
        /// Vista para crear o editar un curso
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(long? id)
        {
            Curso curso;
            if (id == null)
            {
                // -- Seteo titulo
                ViewBag.Title = "Crear Curso";
                // Creo curso
                curso = new Curso();
            }
            else
            {
                // -- Seteo titulo
                ViewBag.Title = "Editar Curso";
                // -- Recupero curso
                curso = logic.GetByID(id.Value);
                // -- Asigno rol seleccionado
                ViewBag.selectedddlRol = curso.RolMinimo.EntityID;
            }
            return View(curso);
        }

        [HttpPost]
        public ActionResult Save([Bind] Curso curso, long ddlRol)
        {
            var imageFile = Request.Files["ImagenCurso"];

            if (curso.EntityID == 0)
            {
                // -- Obtengo archivos e imagenCurso
                var file = Request.Files["Archivo"];

                // -- Si carga archivos
                if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
                {
                    if (curso.Html != null && curso.Html != "")
                    {
                        FileInfo fileInfo = new FileInfo(file.FileName);
                        if (fileInfo.Extension.ToLower().Equals(".rar") || fileInfo.Extension.ToLower().Equals(".zip"))
                        {
                            curso.RolMinimo = new Rol { EntityID = ddlRol };
                            if (ModelState.IsValid)
                            {
                                string appPath = HttpContext.Server.MapPath("~/Cursos/");
                                // -- Agrego curso
                                logic.AddCurso(curso, appPath, file.InputStream);

                                TempData["SaveSuccess"] = "Se guardó curso correctamente";
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Archivo", "Debe cargar un archivo del tipo zip o rar");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("NombreHTML", "Debe ingresar nombre HTML del curso");
                        ModelState.AddModelError("Archivo", "Vuelva a cargar el archivo deseado");
                        TempData["Notice"] = "Si carga archivos de curso debe ingresar nombre HTML";
                    }
                }
                // -- Si carga imagenCurso
                else if (imageFile != null && imageFile.ContentLength > 0 && !string.IsNullOrEmpty(imageFile.FileName))
                {
                    FileInfo fileInfo = new FileInfo(imageFile.FileName);
                    if (fileInfo.Extension.ToLower().Equals(".jpg") || fileInfo.Extension.ToLower().Equals(".jpeg") || fileInfo.Extension.ToLower().Equals(".gif") || fileInfo.Extension.ToLower().Equals(".png"))
                    {
                        curso.RolMinimo = new Rol { EntityID = ddlRol };
                        if (ModelState.IsValid)
                        {
                            string appPath = HttpContext.Server.MapPath(ImagenesPath);
                            // -- Agrego curso
                            logic.AddCurso(curso, appPath, imageFile.InputStream, fileInfo.Extension);

                            TempData["SaveSuccess"] = "Se guardó curso correctamente";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImagenCurso", "Debe cargar una imagen del tipo .jpg .jpeg .gif o .png");
                    }
                }
                else
                {
                    curso.RolMinimo = new Rol { EntityID = ddlRol };
                    if (ModelState.IsValid)
                    {
                        logic.AddCurso(curso);

                        TempData["SaveSuccess"] = "Se guardó curso correctamente";
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                // -- Actualizo curso

                // -- Si tiene imagen
                if (imageFile != null && imageFile.ContentLength > 0 && !string.IsNullOrEmpty(imageFile.FileName))
                {
                    FileInfo fileInfo = new FileInfo(imageFile.FileName);
                    if (fileInfo.Extension.ToLower().Equals(".jpg") || fileInfo.Extension.ToLower().Equals(".jpeg") || fileInfo.Extension.ToLower().Equals(".gif") || fileInfo.Extension.ToLower().Equals(".png"))
                    {
                        curso.RolMinimo = new Rol { EntityID = ddlRol };
                        if (ModelState.IsValid)
                        {
                            string appPath = HttpContext.Server.MapPath(ImagenesPath);
                            // -- Agrego curso
                            logic.UpdateCurso(curso, appPath, imageFile.InputStream, fileInfo.Extension);

                            TempData["SaveSuccess"] = "Se guardó curso correctamente";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImagenCurso", "Debe cargar una imagen del tipo .jpg .jpeg .gif o .png");
                    }
                }
                else
                {
                    if (curso.Imagen == null)
                    {
                        string[] extensions = { ".jpg", ".jpeg", ".png", ".gif" };
                        // -- Si existe la imagen la borro
                        string appPath = HttpContext.Server.MapPath(ImagenesPath);
                        string deletePath;
                        for (int i = 0; i <= 3; i++)
                        {
                            deletePath = appPath + string.Format(ImagenCursoPath, curso.EntityID, extensions[i]);
                            if (System.IO.File.Exists(deletePath))
                            {
                                System.IO.File.Delete(deletePath);
                            }
                        }
                    }

                    curso.RolMinimo = new Rol { EntityID = ddlRol };
                    logic.Update(curso);
                    TempData["SaveSuccess"] = "Se guardó curso correctamente";
                    return RedirectToAction("Index");
                }
            }

            // -- Seteo valor seleccionado para rol
            ViewBag.selectedddlRol = ddlRol;
            return View(curso);
        }

        /// <summary>
        /// Vista para cargar archivos de un curso
        /// </summary>
        /// <returns></returns>
        public ActionResult RecargarCurso(long? id)
        {
            Curso curso;
            // -- Seteo titulo
            ViewBag.Title = "Editar Curso - Recargar";
            // -- Recupero curso
            curso = logic.GetByID(id.Value);

            return View(curso);
        }

        /// <summary>
        /// Guarda archivos para el curso
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RecargarCurso([Bind] Curso curso)
        {
            // -- Obtengo archivo
            var file = Request.Files["Archivo"];

            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
            {
                FileInfo fileInfo = new FileInfo(file.FileName);
                if (fileInfo.Extension.ToLower().Equals(".rar") || fileInfo.Extension.ToLower().Equals(".zip"))
                {
                    if (ModelState.IsValid)
                    {
                        string appPath = HttpContext.Server.MapPath("~/Cursos/");
                        // -- Agrego curso
                        logic.RecargarCurso(curso, appPath, file.InputStream);
                        TempData["SaveSuccess"] = "Se subieron archivos correctamente";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("Archivo", "Debe cargar un archivo del tipo zip o rar");
                }
            }
            else
            {
                ModelState.AddModelError("Archivo", "Debe cargar un archivo");
            }
            return View(curso);
        }

        /// <summary>
        /// Ver el contenido del curso
        /// </summary>
        /// <returns></returns>
        public ActionResult VerCurso(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            // -- Recupero curso
            var curso = logic.ValidarCursoParaUsuarioLogueado(id.Value);
            if (curso != null)
            {
                // -- Si tiene acceso
                ViewBag.TieneAcceso = true;
                // -- Inicio el curso Usuario
                CursoUsuarioLogic.IniciarCursoUsuario(curso.EntityID);

                string html = curso.Html;
                // -- Si no tiene extension, la agrego
                if (!html.EndsWith("html"))
                {
                    html += ".html";
                }
                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                // -- Concateno 
                baseUrl += "Cursos/" + curso.FilesFolder + "/" + html;

                // -- Valido que el archivo del curso exista
                if (System.IO.File.Exists(HttpContext.Server.MapPath("~/Cursos/") + curso.FilesFolder + "/" + html))
                {
                    ViewBag.ExisteCurso = true;
                }
                else
                {
                    ViewBag.ExisteCurso = false;
                }
                ViewBag.Url = baseUrl;
            }
            else
            {
                // -- Si no tiene acceso
                ViewBag.TieneAcceso = false;
            }
            return View();
        }

        /// <summary>
        /// Muestra cursos para un usuario logueado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MisCursos()
        {
            var cursos = logic.RecuperarCursosParaUsuarioLogueado();
            return View(cursos);
        }

        /// <summary>
        /// Ver el contenido del curso
        /// </summary>
        /// <returns></returns>
        public ActionResult VerCursoAdmin(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            // -- Recupero curso
            var curso = logic.GetByID(id.Value);
            if (curso != null)
            {
                // -- Si tiene acceso
                ViewBag.TieneAcceso = true;
                string html = curso.Html;
                // -- Si no tiene extension, la agrego
                if (!html.EndsWith("html"))
                {
                    html += ".html";
                }
                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                // -- Concateno 
                baseUrl += "Cursos/" + curso.FilesFolder + "/" + html;

                // -- Valido que el archivo del curso exista
                if (System.IO.File.Exists(HttpContext.Server.MapPath("~/Cursos/") + curso.FilesFolder + "/" + html))
                {
                    ViewBag.ExisteCurso = true;
                }
                else
                {
                    ViewBag.ExisteCurso = false;
                }
                ViewBag.Url = baseUrl;
            }
            else
            {
                // -- Si no existe el curso
                ViewBag.TieneAcceso = true;
                ViewBag.ExisteCurso = false;
            }
            return View("VerCurso");
        }

        /// <summary>
        /// Muestra vista para realizar examen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult HacerExamen(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            // -- Recupero curso
            var curso = logic.ValidarCursoParaUsuarioLogueado(id.Value);
            if (curso != null)
            {
                // -- Si el curso no fue iniciado(no fue visto)
                var cursoUsuario = CursoUsuarioLogic.GetByCursoID(curso.EntityID);
                if (cursoUsuario == null)
                {
                    TempData["Notice"] = "Debe ver el curso antes de realizar el examen";
                    return RedirectToAction("MisCursos", "Curso");
                }
                // -- Si ya se realizo el examen para el curso
                if (cursoUsuario.EstadoCurso.EntityID == (long)Entities.EstadoCurso.EstadosCursos.EvaluacionRealizada)
                {
                    TempData["Notice"] = "Ya realizo el examen para el curso";
                    return RedirectToAction("MisCursos", "Curso");
                }
                CursoUsuarioLogic.ActualizarEstado(cursoUsuario.EntityID, (long)Entities.EstadoCurso.EstadosCursos.EvaluacionVista);
                // -- Filtro preguntas activas
                curso.Preguntas = curso.Preguntas.Where(x => x.Activo).ToList();

                return View(curso);
            }
            else
            {
                // -- Si no tiene acceso
                return RedirectToAction("NoAutorizado", "Error");
            }
        }

        /// <summary>
        /// Guarda el examen realizado
        /// </summary>
        /// <param name="preguntas">preguntas del examen del curso</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HacerExamen(List<Pregunta> preguntas, long cursoID)
        {
            var resultado = CursoUsuarioLogic.GuardarExamenRealizado(preguntas, cursoID);

            PreguntaLogic preguntaLogic = new PreguntaLogic();
            var listaPreguntas = preguntaLogic.GetPreguntasByCurso(cursoID);
            foreach(Pregunta pregunta in listaPreguntas)
            {
                pregunta.Curso = new Curso();
                foreach(Opcion opcion in pregunta.Opciones)
                {
                    opcion.Pregunta = new Pregunta();
                }
            }

            string mensaje;
            if(resultado>=60)
            {
                mensaje = "Felecitaciones, aprobaste, tu nota es: " + resultado;

                // -- Obtengo usuario logueado
                var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);

                MailLogic mailLogic = new MailLogic();

                mailLogic.EnviarEmail(usuarioLogueado.EntityID, usuarioLogueado.Password, Global.MailsTypes.CURSO_FINALIZADO);

                List<Usuario> usuariosEmpresaMails = new UsuarioLogic().GetUsuarioEmpresaParaMail(usuarioLogueado.Empresa.EntityID);

                foreach (Usuario usu in usuariosEmpresaMails)
                {
                    mailLogic.EnviarEmail(usu.EntityID, usu.Password, Global.MailsTypes.CURSO_FINALIZADO);
                }
            }
            else
            {
                mensaje = "No aprobaste, tu nota es: " + resultado;
            }
            ExamenJSON examen = new ExamenJSON { Preguntas = listaPreguntas, Mensaje = mensaje };

            return Json(examen, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Reporte de cursos por usuario
        /// </summary>
        /// <returns></returns>
        public ActionResult ReporteCursosUsuarios()
        {
            return View(new List<CursoUsuario>());
        }

        /// <summary>
        /// Genera el reporte
        /// </summary>
        /// <param name="ddlCurso"></param>
        /// <returns></returns>
        public ActionResult GenerarReporteCursosUsuarios(long ddlCurso)
        {
            DataTable tabla = CursoUsuarioLogic.GetForReport(ddlCurso);

            string mime = string.Empty;

            
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Obtengo curso
            var curso = logic.GetByID(ddlCurso);

            // -- Agrego parametro
            var parameters = new List<Microsoft.Reporting.WebForms.ReportParameter>
                {
                    new Microsoft.Reporting.WebForms.ReportParameter("Empresa", usuarioLogueado.Empresa.Nombre),
                    new Microsoft.Reporting.WebForms.ReportParameter("Curso", curso.Nombre)
                };

            //genera los bytes del reporte a ser enviado al browser
            var bytes = ReportHelper.Create(System.AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Rdlcs\CursosUsuarios.rdlc", tabla, parameters, "CursosUsuarios", ref mime);


            return File(bytes, mime);
        }

        /// <summary>
        /// Borra curso
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public JsonResult BorrarCurso(long cursoID)
        {
            logic.BorrarCurso(cursoID);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Clase auxiliar para hacer examen
        /// </summary>
        private class ExamenJSON
        {
            /// <summary>
            /// Lista de preguntas
            /// </summary>
            public List<Pregunta> Preguntas { get; set; }

            /// <summary>
            /// Mensaje de resultado
            /// </summary>
            public string Mensaje { get; set; }
        }

        public ActionResult MiCertificado(long id)
        {
            DataTable tabla = CursoUsuarioLogic.RecuperarCertificado(id);

            if (tabla.Rows.Count > 0)
            {
                if (Convert.ToInt32(tabla.Rows[0]["codigoRespuesta"]) == 1) //Aprobado
                {
                    string mime = string.Empty;

                    string imagePath = new Uri(Server.MapPath("~/Imagenes/LogosEmpresas/" + Convert.ToString(tabla.Rows[0]["imagenEmpresa"]))).AbsoluteUri;
                    // -- Agrego parametro
                    var parameters = new List<Microsoft.Reporting.WebForms.ReportParameter>
                    {
                        new Microsoft.Reporting.WebForms.ReportParameter("txtNombreEmpleado", Convert.ToString(tabla.Rows[0]["nombre"])),
                        new Microsoft.Reporting.WebForms.ReportParameter("txtNombreEmpresa", Convert.ToString(tabla.Rows[0]["empresa"])),
                        new Microsoft.Reporting.WebForms.ReportParameter("txtNombreCurso", Convert.ToString(tabla.Rows[0]["curso"])),
                        new Microsoft.Reporting.WebForms.ReportParameter("txtNombreApellidoPresidente", "Nombre Empresa"),
                         new Microsoft.Reporting.WebForms.ReportParameter("txtUrlImagenEmpresa",imagePath)
                    };

                    //genera los bytes del reporte a ser enviado al browser
                    var bytes = ReportHelper.Create(System.AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Rdlcs\Certificado.rdlc", tabla, parameters, "CursosUsuarios", ref mime);


                    return File(bytes, mime);
                }
                else if (Convert.ToInt32(tabla.Rows[0]["codigoRespuesta"]) == 2) //No aprobado
                {
                    TempData["Notice"] = "Debe aprobar el examen previamente";
                    return RedirectToAction("MisCursos", "Curso");
                }
                else if (Convert.ToInt32(tabla.Rows[0]["codigoRespuesta"]) == 3) //No realizado
                {
                    TempData["Notice"] = "Debe realizar el examen previamente";
                    return RedirectToAction("MisCursos", "Curso");
                }   
            }

            return View();
        }
    }
}