using Cross.Common;
using Entities;
using Fwk.Session;
using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.Controllers
{
    public class EmpresaController : BaseController<Empresa, EmpresaLogic>
    {
        #region Logics

        CursoLogic cursoLogic;
        /// <summary>
        /// Curso logic
        /// </summary>
        CursoLogic CursoLogic
        {
            get
            {
                if (cursoLogic == null)
                {
                    cursoLogic = new CursoLogic();
                }
                return cursoLogic;
            }
        }

        EmpresaCursoLogic empresaCursoLogic;
        EmpresaCursoLogic EmpresaCursoLogic
        {
            get
            {
                if(empresaCursoLogic==null)
                {
                    empresaCursoLogic = new EmpresaCursoLogic();
                }
                return empresaCursoLogic;
            }
        }

        #endregion
        // GET: Empresa
        public ActionResult Index()
        {
            // -- recupero empresas
            var empresas = logic.GetAllActivos();
            // -- devuelvo vista
            return View(empresas);
        }

        /// <summary>
        /// Muestra vista de alta y modificacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Save(long? id)
        {
            Empresa empresa;
            if (id == null)
            {
                // -- Seteo titulo
                ViewBag.Title = "Crear Empresa";
                // -- Creo empresa
                empresa = new Empresa();
            }
            else
            {
                // -- Seteo titulo
                ViewBag.Title = "Editar Empresa";
                // -- Recupero empresa
                empresa = logic.GetByID(id.Value);
            }
            // -- Devuelvo vista
            return View(empresa);
        }

        [HttpPost]
        /// <summary>
        /// Guarda empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public ActionResult Save([Bind]Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                if (empresa.EntityID == 0)
                {
                    // -- Activo
                    empresa.Activo = true;
                    // -- Agrega empresa
                    logic.Add(empresa);
                }
                else
                {
                    // -- Actualiza empresa
                    logic.Update(empresa);
                }
                // -- Devuelvo vista
                return RedirectToAction("Index");
            }
            TempData["SaveSuccess"] = "Se guardó empresa correctamente";
            // -- Devuelvo vista
            return View(empresa);
        }

        /// <summary>
        /// Asignar curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AsignarCursos(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            // -- Recupero empresa
            var empresa = logic.GetByID(id.Value);
            // -- Obtengo cursos
            var cursos = CursoLogic.GetAllActivos();
            // -- Asigno cursos a ViewBag
            ViewBag.CursosID = new MultiSelectList(cursos, "EntityID", "Nombre", empresa.EmpresaCursos.Select(x => x.Curso.EntityID));
            // -- Retorno vista
            return View(empresa);
        }

        /// <summary>
        /// Asignar cursos post
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="CursosID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AsignarCursos([Bind]Empresa empresa, long[] CursosID)
        {
            if (CursosID != null)
            {
                // -- Asigno cursos
                foreach (long cursoID in CursosID)
                {
                    EmpresaCurso empresaCurso = new EmpresaCurso { TieneLimite = false, Activo = true };
                    Curso curso = new Curso { EntityID = cursoID };
                    empresaCurso.Curso = curso;
                    empresa.EmpresaCursos.Add(empresaCurso);
                }
            }

            logic.AsignarCursos(empresa);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Vista para cargar imagen a la empresa
        /// </summary>
        /// <returns></returns>
        public ActionResult CargarImagen()
        {
            // -- Obtengo usuario
            var usuario = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Retorno vista
            return View(usuario.Empresa);
        }

        /// <summary>
        /// Guarda la imagen para una empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CargarImagen([Bind]Empresa empresa)
        {
            // -- Obtengo archivo
            var file = Request.Files["Archivo"];

            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
            {
                // -- 
                FileInfo fileInfo = new FileInfo(file.FileName);
                // -- Obtengo url para la imagen
                string appPath = HttpContext.Server.MapPath("~/Imagenes/LogosEmpresas/");
                logic.CargarImagen(empresa, file.InputStream, appPath, fileInfo.Extension);
                TempData["SaveSuccess"] = "Se subio imagen correctamente";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Archivo", "Debe cargar una imagen");
            }
            return View(empresa);
        }

        /// <summary>
        /// Cursos de la empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EmpresaCursos(long id)
        {
            var empresa = logic.GetByID(id);
            return View(empresa.EmpresaCursos);
        }

        /// <summary>
        /// Vista para editar empresa cursos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EmpresaCursoSave(long id)
        {
            var empresaCurso = EmpresaCursoLogic.GetByID(id);
            return View(empresaCurso);
        }

        /// <summary>
        /// Guarda una empresa curso
        /// </summary>
        /// <param name="empresaCurso"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EmpresaCursoSave(EmpresaCurso empresaCurso)
        {
            EmpresaCursoLogic.Update(empresaCurso);            
            TempData["SaveSuccess"] = "Se guardó los datos del curso para la empresa correctamente";
            return RedirectToAction("Index");
        }
    }
}