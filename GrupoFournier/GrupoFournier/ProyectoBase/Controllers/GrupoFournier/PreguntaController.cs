using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.Controllers
{
    public class PreguntaController : BaseController<Pregunta, PreguntaLogic>
    {
        // GET: Pregunta
        /// <summary>
        /// Vista de preguntas de un curso
        /// </summary>
        /// <param name="id">id del curso</param>
        /// <returns></returns>
        public ActionResult Index(long id)
        {
            // -- Guardo id de curso en viewbag
            ViewBag.CursoID = id;
            // -- Recupero preguntas de un curso
            var preguntas = logic.GetPreguntasByCurso(id);
            return View(preguntas);
        }

        /// <summary>
        /// Vista para editar una pregunta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long id)
        {
            // -- Recupera pregunta
            Pregunta pregunta = logic.GetByID(id);

            return View(pregunta);
        }

        /// <summary>
        /// Vista para crear una pregunta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Create(long id)
        {
            // -- Recupera pregunta
            Pregunta pregunta = new Pregunta { Activo = true, Curso = new Curso { EntityID = id } };

            return View(pregunta);
        }

        /// <summary>
        /// Guarda una nueva pregunta
        /// </summary>
        /// <param name="pregunta"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Pregunta pregunta)
        {
            logic.Add(pregunta);
            TempData["SaveSuccess"] = "Se guardo pregunta correctamente";
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Actualiza una pregunta con sus opciones
        /// </summary>
        /// <param name="pregunta"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Pregunta pregunta)
        {
            logic.Update(pregunta);
            TempData["SaveSuccess"] = "Se guardo pregunta correctamente";
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Elimina una pregunta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Deshabilitar(long id)
        {
            logic.Delete(id);
            TempData["SaveSuccess"] = "Se deshabilito la pregunta correctamente";
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}