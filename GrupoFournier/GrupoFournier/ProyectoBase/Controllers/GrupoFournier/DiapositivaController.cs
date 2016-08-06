using Cross.Common;
using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using NAudio.Wave;
using Logic.GrupoFournier;

namespace PresentacionGrupoFournier.Controllers
{
    public class DiapositivaController : BaseController<Diapositiva, DiapositivaLogic>
    {
        #region CONST
        private const string ImagenesPath = "~/Imagenes/ImagenesCursos/";
        private const string VideosPath = "~/Imagenes/VideosCursos/";
        private const string AudiosPath = "~/Imagenes/AudiosCursos/";

        // -- El formato sería "curso" + diapositiva.Curso.EntityID + "diapositiva" + diapositiva.EntityID + extension
        // -- Ejemplo "curso1diapositiva2.jpg"
        private const string ImagenDiapositivaPath = "curso{0}diapositiva{1}{2}";

        // -- El formato sería "diapositiva" + diapositiva.EntityID + "-" + posición + extension
        private const string AudioDiapositivaPath = "diapositiva{0}-{1}{2}";

        #endregion

        #region Members

        Diapositiva diapositvaPorOrden { get; set; }

        #endregion

        #region Logics

        private CursoUsuarioLogic cursoUsuarioLogic;
        public CursoUsuarioLogic CursoUsuarioLogic
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

        private CursoLogic cursoLogic;
        public CursoLogic CursoLogic
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

        #endregion
        // GET: Diapositiva
        public ActionResult Index(long cursoID)
        {
            var diapositivas = logic.GetByCurso(cursoID);
            ViewBag.cursoID = cursoID;
            if (diapositivas.Count != 0)
            {
                ViewBag.cursoName = diapositivas.First().Curso.Nombre;
            }
            else
            {
                ViewBag.cursoName = this.CursoLogic.GetByID(cursoID).Nombre;
            }
            return View(diapositivas);
        }

        public ActionResult Save(long? diapositivaID, long cursoID)
        {
            // -- Inicio VM
            DiapositivaVM dvm = new DiapositivaVM();
            // -- Inicio diapositiva
            Diapositiva diapositiva;
            // -- Recupero las diapositivas del curso
            var diapositivasCurso = logic.GetByCurso(cursoID);

            if (diapositivaID == null)
            {
                ViewBag.Title = "Crear Diapositiva";
                diapositiva = new Diapositiva { Curso = new Curso { EntityID = cursoID }, Orden = 1, ColorTitulo = "#000000" };
            }
            else
            {
                ViewBag.Title = "Editar Diapositiva";
                diapositiva = logic.GetByID(diapositivaID.Value);
                // -- Saco de la lista la diapositiva actual para no generar referencia a si misma
                diapositivasCurso = diapositivasCurso.Where(x => x.EntityID != diapositivaID.Value).ToList();
                // -- Seteo la plantilla seleccionada
                ViewBag.selectedddlPlantilla = diapositiva.Plantilla.EntityID;

                #region Botones

                foreach (var boton in diapositiva.Botones)
                {
                    switch (boton.Orden)
                    {
                        case 1:
                            dvm.TituloBoton1 = boton.Nombre;
                            dvm.ColorBoton1 = boton.Color;
                            dvm.ContenidoBoton1 = boton.Contenido;
                            break;
                        case 2:
                            dvm.TituloBoton2 = boton.Nombre;
                            dvm.ColorBoton2 = boton.Color;
                            dvm.ContenidoBoton2 = boton.Contenido;
                            break;
                        case 3:
                            dvm.TituloBoton3 = boton.Nombre;
                            dvm.ColorBoton3 = boton.Color;
                            dvm.ContenidoBoton3 = boton.Contenido;
                            break;
                        case 4:
                            dvm.TituloBoton4 = boton.Nombre;
                            dvm.ColorBoton4 = boton.Color;
                            dvm.ContenidoBoton4 = boton.Contenido;
                            break;
                        case 5:
                            dvm.TituloBoton5 = boton.Nombre;
                            dvm.ColorBoton5 = boton.Color;
                            dvm.ContenidoBoton5 = boton.Contenido;
                            break;
                    }
                }

                #endregion

                #region Textos centrados y horizontales

                if (diapositiva.Plantilla.EntityID == ParameterProvider.TipoPlantilla.TextosCentrados || diapositiva.Plantilla.EntityID == ParameterProvider.TipoPlantilla.TextosApiladosHorizontal)
                {
                    foreach (var texto in diapositiva.Textos)
                    {
                        switch (texto.Orden)
                        {
                            case 1:
                                dvm.TextoAlineado1 = texto.Contenido;
                                break;
                            case 2:
                                dvm.TextoAlineado2 = texto.Contenido;
                                break;
                            case 3:
                                dvm.TextoAlineado3 = texto.Contenido;
                                break;
                            case 4:
                                dvm.TextoAlineado4 = texto.Contenido;
                                break;
                            case 5:
                                dvm.TextoAlineado5 = texto.Contenido;
                                break;
                        }
                    }
                }

                #endregion

                #region Textos zonas

                if (diapositiva.Plantilla.EntityID == ParameterProvider.TipoPlantilla.TextosDiferentesPosiciones)
                {
                    foreach (var texto in diapositiva.Textos)
                    {
                        switch (texto.Orden)
                        {
                            case 1:
                                dvm.TextoDistribuido1 = texto.Contenido;
                                break;
                            case 2:
                                dvm.TextoDistribuido2 = texto.Contenido;
                                break;
                            case 3:
                                dvm.TextoDistribuido3 = texto.Contenido;
                                break;
                            case 4:
                                dvm.TextoDistribuido4 = texto.Contenido;
                                break;
                            case 5:
                                dvm.TextoDistribuido5 = texto.Contenido;
                                break;
                        }
                    }
                }

                #endregion

                #region Video

                if (diapositiva.Plantilla.EntityID == ParameterProvider.TipoPlantilla.Video)
                {
                    dvm.Video = diapositiva.Video;
                }
                #endregion

            }
            // -- Armo la lista
            ViewBag.DiapositivasID = new MultiSelectList(diapositivasCurso, "EntityID", "Titulo", diapositiva.DiapositivasReferidas.Select(x => x.EntityID));

            dvm.Diapositiva = diapositiva;

            return View(dvm);
        }

        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        /// <summary>
        /// Guarda Diapositiva
        /// </summary>
        /// <param name="diapositiva"></param>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public ActionResult Save(DiapositivaVM dvm, long cursoID, List<long> DiapositivasID, long ddlPlantilla, bool isDiapositivaAudio)
        {
            // -- Seteo la plantilla
            dvm.Diapositiva.Plantilla = new Plantilla { EntityID = ddlPlantilla };
            // -- Seteo si la diapositiva es de audio
            dvm.Diapositiva.IsDiapositivaAudio = isDiapositivaAudio;
            // -- Si viene como nulo lo instancio
            if (DiapositivasID == null) DiapositivasID = new List<long>();
            // -- Recupero diapositva por orden
            diapositvaPorOrden = logic.GetByOrdenYCurso(cursoID, dvm.Diapositiva.Orden);
            // -- SI existe diapositva con el orden ingresado
            if (diapositvaPorOrden != null && dvm.Diapositiva.EntityID != diapositvaPorOrden.EntityID)
            {
                // -- Agrego el error
                ModelState.AddModelError("Diapositiva.Orden", "Ya existe una diapositiva con el orden ingresado");
            }

            if (ModelState.IsValid)
            {
                // -- Agrego diapositivas
                dvm.Diapositiva.DiapositivasReferidas = new List<Diapositiva>();
                DiapositivasID.ForEach(x => dvm.Diapositiva.DiapositivasReferidas.Add(new Diapositiva { EntityID = x }));
                dvm.Diapositiva.Curso = new Curso { EntityID = cursoID };

                #region Tipo de plantilla

                double duracion = 0;
                double duracionTotal = 0;
                switch (ddlPlantilla)
                {
                    case ParameterProvider.TipoPlantilla.Botones:
                        #region Botones
                        if (!string.IsNullOrWhiteSpace(dvm.TituloBoton1))
                        {
                            Boton boton1 = new Boton { Orden = 1, Color = dvm.ColorBoton1, Contenido = dvm.ContenidoBoton1, Nombre = dvm.TituloBoton1, Activo = true };
                            boton1.Audio = SubirArchivoAudio(dvm, "AudioBoton1", 1, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Botones.Add(boton1);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TituloBoton2))
                        {
                            Boton boton2 = new Boton { Orden = 2, Color = dvm.ColorBoton2, Contenido = dvm.ContenidoBoton2, Nombre = dvm.TituloBoton2, Activo = true };
                            boton2.Audio = SubirArchivoAudio(dvm, "AudioBoton2", 2, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Botones.Add(boton2);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TituloBoton3))
                        {
                            Boton boton3 = new Boton { Orden = 3, Color = dvm.ColorBoton3, Contenido = dvm.ContenidoBoton3, Nombre = dvm.TituloBoton3, Activo = true };
                            boton3.Audio = SubirArchivoAudio(dvm, "AudioBoton3", 3, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Botones.Add(boton3);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TituloBoton4))
                        {
                            Boton boton4 = new Boton { Orden = 4, Color = dvm.ColorBoton4, Contenido = dvm.ContenidoBoton4, Nombre = dvm.TituloBoton4, Activo = true };
                            boton4.Audio = SubirArchivoAudio(dvm, "AudioBoton4", 4, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Botones.Add(boton4);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TituloBoton5))
                        {
                            Boton boton5 = new Boton { Orden = 5, Color = dvm.ColorBoton5, Contenido = dvm.ContenidoBoton5, Nombre = dvm.TituloBoton5, Activo = true };
                            boton5.Audio = SubirArchivoAudio(dvm, "AudioBoton5", 5, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Botones.Add(boton5);
                        }
                        break;
                    #endregion
                    case ParameterProvider.TipoPlantilla.TextosCentrados:
                        #region Textos centrados y horizontales
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado1))
                        {
                            Texto texto1 = new Texto { Orden = 1, Contenido = dvm.TextoAlineado1, Activo = true };
                            texto1.TiempoDeArranque = duracionTotal;
                            texto1.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado1", 1, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto1);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado2))
                        {
                            Texto texto2 = new Texto { Orden = 2, Contenido = dvm.TextoAlineado2, Activo = true };
                            texto2.TiempoDeArranque = duracionTotal;
                            texto2.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado2", 2, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto2);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado3))
                        {
                            Texto texto3 = new Texto { Orden = 3, Contenido = dvm.TextoAlineado3, Activo = true };
                            texto3.TiempoDeArranque = duracionTotal;
                            texto3.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado3", 3, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto3);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado4))
                        {
                            Texto texto4 = new Texto { Orden = 4, Contenido = dvm.TextoAlineado4, Activo = true };
                            texto4.TiempoDeArranque = duracionTotal;
                            texto4.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado4", 4, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto4);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado5))
                        {
                            Texto texto5 = new Texto { Orden = 5, Contenido = dvm.TextoAlineado5, Activo = true };
                            texto5.TiempoDeArranque = duracionTotal;
                            texto5.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado5", 5, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto5);
                        }
                        break;
                    #endregion
                    case ParameterProvider.TipoPlantilla.TextosDiferentesPosiciones:
                        #region Textos zonas

                        if (!string.IsNullOrWhiteSpace(dvm.TextoDistribuido1))
                        {
                            Texto texto1 = new Texto { Orden = 1, Contenido = dvm.TextoDistribuido1, Activo = true };
                            texto1.TiempoDeArranque = duracionTotal;
                            texto1.Audio = SubirArchivoAudio(dvm, "AudioTextoDistribuido1", 1, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto1);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoDistribuido2))
                        {
                            Texto texto2 = new Texto { Orden = 2, Contenido = dvm.TextoDistribuido2, Activo = true };
                            texto2.TiempoDeArranque = duracionTotal;
                            texto2.Audio = SubirArchivoAudio(dvm, "AudioTextoDistribuido2", 2, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto2);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoDistribuido3))
                        {
                            Texto texto3 = new Texto { Orden = 3, Contenido = dvm.TextoDistribuido3, Activo = true };
                            texto3.TiempoDeArranque = duracionTotal;
                            texto3.Audio = SubirArchivoAudio(dvm, "AudioTextoDistribuido3", 3, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto3);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoDistribuido4))
                        {
                            Texto texto4 = new Texto { Orden = 4, Contenido = dvm.TextoDistribuido4, Activo = true };
                            texto4.TiempoDeArranque = duracionTotal;
                            texto4.Audio = SubirArchivoAudio(dvm, "AudioTextoDistribuido4", 4, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto4);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoDistribuido5))
                        {
                            Texto texto5 = new Texto { Orden = 5, Contenido = dvm.TextoDistribuido5, Activo = true };
                            texto5.TiempoDeArranque = duracionTotal;
                            texto5.Audio = SubirArchivoAudio(dvm, "AudioTextoDistribuido5", 5, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto5);
                        }

                        #endregion
                        break;
                    case ParameterProvider.TipoPlantilla.TextosApiladosHorizontal:
                        #region Textos horizontales
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado1))
                        {
                            Texto texto1 = new Texto { Orden = 1, Contenido = dvm.TextoAlineado1, Activo = true };
                            texto1.TiempoDeArranque = duracionTotal;
                            texto1.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado1", 1, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto1);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado2))
                        {
                            Texto texto2 = new Texto { Orden = 2, Contenido = dvm.TextoAlineado2, Activo = true };
                            texto2.TiempoDeArranque = duracionTotal;
                            texto2.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado2", 2, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto2);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado3))
                        {
                            Texto texto3 = new Texto { Orden = 3, Contenido = dvm.TextoAlineado3, Activo = true };
                            texto3.TiempoDeArranque = duracionTotal;
                            texto3.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado3", 3, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto3);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado4))
                        {
                            Texto texto4 = new Texto { Orden = 4, Contenido = dvm.TextoAlineado4, Activo = true };
                            texto4.TiempoDeArranque = duracionTotal;
                            texto4.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado4", 4, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto4);
                        }
                        if (!string.IsNullOrWhiteSpace(dvm.TextoAlineado5))
                        {
                            Texto texto5 = new Texto { Orden = 5, Contenido = dvm.TextoAlineado5, Activo = true };
                            texto5.TiempoDeArranque = duracionTotal;
                            texto5.Audio = SubirArchivoAudio(dvm, "AudioTextoAlineado5", 5, ref duracion);
                            duracionTotal += duracion;
                            dvm.Diapositiva.Textos.Add(texto5);
                        }
                        break;
                    #endregion
                    case ParameterProvider.TipoPlantilla.Video:
                        #region Video
                        var videoFile = Request.Files["VideoDiapositiva"];
                        // -- Si tiene video
                        if (videoFile != null && videoFile.ContentLength > 0 && !string.IsNullOrEmpty(videoFile.FileName))
                        {
                            FileInfo fileInfo = new FileInfo(videoFile.FileName);
                            if (fileInfo.Extension.ToLower().Equals(".mp4")
                                || fileInfo.Extension.ToLower().Equals(".avi")
                                || fileInfo.Extension.ToLower().Equals(".mpeg")
                                || fileInfo.Extension.ToLower().Equals(".mpg")
                                || fileInfo.Extension.ToLower().Equals(".wmv"))
                            {
                                // -- Puntero
                                if (ModelState.IsValid)
                                {
                                    // -- Si es nuevo lo agrego para tener el id del video
                                    if (dvm.Diapositiva.EntityID == 0)
                                    {
                                        logic.Add(dvm.Diapositiva);
                                    }

                                    string appPath = HttpContext.Server.MapPath(VideosPath);

                                    Stream fileStream = videoFile.InputStream;
                                    string extension = fileInfo.Extension;

                                    var length = Convert.ToInt32(fileStream.Length);
                                    byte[] data = null;

                                    using (var reader = new BinaryReader(fileStream))
                                    {
                                        data = reader.ReadBytes(length);
                                    }

                                    string[] extensions = { ".mp4", ".avi", ".mpeg", ".mpg", ".wmv" };
                                    string deletePath;

                                    // -- Si existe la imagen la borro
                                    for (int i = 0; i <= 4; i++)
                                    {
                                        deletePath = appPath + string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extensions[i]);
                                        if (System.IO.File.Exists(deletePath))
                                        {
                                            System.IO.File.Delete(deletePath);
                                        }
                                    }

                                    // -- Creo video
                                    appPath += string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extension);
                                    var file = new FileStream(appPath, FileMode.Create, FileAccess.Write);
                                    file.Write(data, 0, length);
                                    file.Close();

                                    // -- Asigno video a diapositiva
                                    dvm.Diapositiva.Video = string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extension);

                                    //logic.Update(dvm.Diapositiva); -- Se guarda cuando sale del switch

                                    TempData["SaveSuccess"] = "Se guardó diapositiva correctamente";
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("VideoDiapositiva", "Debe cargar un video del tipo .mp4, .avi, .mpeg, .mpg o .wmv");
                            }
                        }
                        else if (dvm.Diapositiva.Video == null)
                        {
                            string[] extensions = { ".mp4", ".avi", ".mpeg", ".mpg", ".wmv" };
                            // -- Si existe el video lo borro
                            string appPath = HttpContext.Server.MapPath(VideosPath);
                            string deletePath;
                            for (int i = 0; i <= 3; i++)
                            {
                                deletePath = appPath + string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extensions[i]);
                                if (System.IO.File.Exists(deletePath))
                                {
                                    System.IO.File.Delete(deletePath);
                                }
                            }
                        }
                        break;
                        #endregion
                }

                dvm.Diapositiva.TiempoTotal = duracionTotal;

                // -- Agrego o edito diapositiva
                if (dvm.Diapositiva.EntityID == 0)
                {
                    logic.Add(dvm.Diapositiva);
                    RenombrarAudios(dvm.Diapositiva.EntityID, ".mp3");
                }
                else
                {
                    logic.Update(dvm.Diapositiva);
                }

                #endregion

                #region Cargo Imagen de Diapositiva

                var imageFile = Request.Files["ImagenDiapositiva"];
                // -- Si tiene imagen
                if (imageFile != null && imageFile.ContentLength > 0 && !string.IsNullOrEmpty(imageFile.FileName))
                {
                    FileInfo fileInfo = new FileInfo(imageFile.FileName);
                    if (fileInfo.Extension.ToLower().Equals(".jpg") || fileInfo.Extension.ToLower().Equals(".jpeg") || fileInfo.Extension.ToLower().Equals(".gif") || fileInfo.Extension.ToLower().Equals(".png"))
                    {
                        // -- Puntero
                        if (ModelState.IsValid)
                        {
                            string appPath = HttpContext.Server.MapPath(ImagenesPath);

                            Stream fileStream = imageFile.InputStream;
                            string extension = fileInfo.Extension;

                            var length = Convert.ToInt32(fileStream.Length);
                            byte[] data = null;

                            using (var reader = new BinaryReader(fileStream))
                            {
                                data = reader.ReadBytes(length);
                            }

                            string[] extensions = { ".jpg", ".jpeg", ".png", ".gif" };
                            string deletePath;
                            // -- Si existe la imagen la borro
                            for (int i = 0; i <= 3; i++)
                            {
                                deletePath = appPath + string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extensions[i]);
                                if (System.IO.File.Exists(deletePath))
                                {
                                    System.IO.File.Delete(deletePath);
                                }
                            }

                            // -- Creo imagen
                            appPath += string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extension);
                            var file = new FileStream(appPath, FileMode.Create, FileAccess.Write);
                            file.Write(data, 0, length);
                            file.Close();

                            // -- Asigno imagen a diapositiva
                            dvm.Diapositiva.Imagen = string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extension);

                            logic.Update(dvm.Diapositiva);

                            TempData["SaveSuccess"] = "Se guardó diapositiva correctamente";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImagenDiapositiva", "Debe cargar una imagen del tipo .jpg .jpeg .gif o .png");
                    }
                }
                else if (dvm.Diapositiva.Imagen == null)
                {
                    string[] extensions = { ".jpg", ".jpeg", ".png", "gif" };
                    // -- Si existe la imagen la borro
                    string appPath = HttpContext.Server.MapPath(ImagenesPath);
                    string deletePath;
                    for (int i = 0; i <= 3; i++)
                    {
                        deletePath = appPath + string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extensions[i]);
                        if (System.IO.File.Exists(deletePath))
                        {
                            System.IO.File.Delete(deletePath);
                        }
                    }
                }

                #endregion

                return RedirectToAction("Index", "Diapositiva", new { cursoID = cursoID });
            }
            // -- Recupero las diapositivas del curso
            var diapositivasCurso = logic.GetByCurso(cursoID);
            // -- Armo la lista
            ViewBag.DiapositivasID = new MultiSelectList(diapositivasCurso, "EntityID", "Titulo", DiapositivasID);
            // -- Se reestablece el curso
            dvm.Diapositiva.Curso = new Curso { EntityID = cursoID };

            // -- Seteo la plantilla seleccionada
            ViewBag.selectedddlPlantilla = ddlPlantilla;

            return View(dvm);
        }

        /// <summary>
        /// Los audios se crean con id de diapositiva 0, lo renombramos al id de diapositiva que corresponde una vez que se guardo en BD
        /// </summary>
        private void RenombrarAudios(long diapositivaID, string extension)
        {
            for (int i = 1; i <= 5; i++)
            {
                string oldPath = HttpContext.Server.MapPath(AudiosPath) + string.Format(AudioDiapositivaPath, 0, i, extension);
                if (System.IO.File.Exists(oldPath))
                {
                    string newPath = HttpContext.Server.MapPath(AudiosPath) + string.Format(AudioDiapositivaPath, diapositivaID, i, extension);
                    System.IO.File.Move(oldPath, newPath);
                }
            }
        }

        /// <summary>
        /// Levanta archivo de audio del control, lo guarda en la carpeta "Audios" de la presentación, devuelve la ruta.
        /// </summary>
        private string SubirArchivoAudio(DiapositivaVM dvm, string control, int posicion, ref double duracion)
        {
            string appPath = HttpContext.Server.MapPath(AudiosPath);
            string path = string.Empty;
            var audioFile = Request.Files[control];

            //Evaluo la diapositiva por orden, si es diferente de null implica que la diapositivaPorOrden es la que se esta editando, por lo tanto si no cargo un archivo le mantengo el que tenia
            if (audioFile.ContentLength == 0 && string.IsNullOrEmpty(audioFile.FileName) && diapositvaPorOrden != null)
            {
                Mp3FileReader fileReader = null;

                if (control.Contains("Texto") && !string.IsNullOrEmpty(diapositvaPorOrden.Textos[posicion - 1].Audio))
                {
                    fileReader = new Mp3FileReader(appPath + diapositvaPorOrden.Textos[posicion - 1].Audio);
                    duracion = fileReader.TotalTime.TotalSeconds;
                    path = diapositvaPorOrden.Textos[posicion - 1].Audio;
                }
                else if (control.Contains("Boton") && !string.IsNullOrEmpty(diapositvaPorOrden.Botones[posicion - 1].Audio))
                {
                    fileReader = new Mp3FileReader(appPath + diapositvaPorOrden.Botones[posicion - 1].Audio);
                    duracion = fileReader.TotalTime.TotalSeconds;
                    path = diapositvaPorOrden.Botones[posicion - 1].Audio;
                }

                return path;
            }
            else if (audioFile != null && audioFile.ContentLength > 0 && !string.IsNullOrEmpty(audioFile.FileName))
            {
                FileInfo fileInfo = new FileInfo(audioFile.FileName);

                if (fileInfo.Extension.ToLower().Equals(".mp3"))
                {
                    // -- Puntero
                    if (ModelState.IsValid)
                    {
                        Stream fileStream = audioFile.InputStream;
                        string extension = fileInfo.Extension;

                        var length = Convert.ToInt32(fileStream.Length);
                        byte[] data = null;

                        using (var reader = new BinaryReader(fileStream))
                        {
                            data = reader.ReadBytes(length);
                        }

                        string[] extensions = { ".mp3" };
                        string deletePath;

                        // -- Si existe el audio lo borro
                        for (int i = 0; i < extensions.Count(); i++)
                        {
                            deletePath = appPath + string.Format(AudioDiapositivaPath, dvm.Diapositiva.EntityID, posicion, extensions[i]);
                            if (System.IO.File.Exists(deletePath))
                            {
                                System.IO.File.Delete(deletePath);
                            }
                        }

                        // -- Creo Audio
                        appPath += string.Format(AudioDiapositivaPath, dvm.Diapositiva.EntityID, posicion, extension);
                        var file = new FileStream(appPath, FileMode.Create, FileAccess.Write);
                        file.Write(data, 0, length);
                        file.Close();

                        // -- Asigno Audio a diapositiva
                        path = string.Format(AudioDiapositivaPath, dvm.Diapositiva.EntityID, posicion, extension);

                        Mp3FileReader fileReader = new Mp3FileReader(appPath);
                        duracion = fileReader.TotalTime.TotalSeconds;

                        TempData["SaveSuccess"] = "Se guardó diapositiva correctamente";
                    }
                }
                else
                {
                    ModelState.AddModelError("AudioDiapositiva", "Debe cargar un audio del tipo .mp3");
                }
            }
            //else if (dvm.Diapositiva.Video == null)
            //{
            //    string[] extensions = { ".mp3" };
            //    // -- Si existe el video lo borro
            //    string appPath = HttpContext.Server.MapPath(AudiosPath);
            //    string deletePath;
            //    for (int i = 0; i <= 3; i++)
            //    {
            //        deletePath = appPath + string.Format(ImagenDiapositivaPath, dvm.Diapositiva.Curso.EntityID, dvm.Diapositiva.EntityID, extensions[i]);
            //        if (System.IO.File.Exists(deletePath))
            //        {
            //            System.IO.File.Delete(deletePath);
            //        }
            //    }
            //}

            return path;
        }

        /// <summary>
        /// Devuelve la vista del curso con las diapositivas
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        //public ActionResult VerCurso(long cursoID, long diapositivaOrden)
        //{
        //    ViewBag.DiapositivaOrden = diapositivaOrden;
        //    var diapositivasCurso = logic.GetByCurso(cursoID);
        //    return View(diapositivasCurso);
        //}

        public ActionResult VerCurso(long id)
        {
            var diapositivasCurso = logic.GetByCurso(id);
            if (diapositivasCurso.Count == 0)
            {
                return RedirectToAction("NotFound", "Error");
            }
            // -- Recupero curso
            CursoLogic cursoLogic = new CursoLogic();
            var curso = cursoLogic.ValidarCursoParaUsuarioLogueado(diapositivasCurso.First().Curso.EntityID);
            // -- Si tiene acceso al curso
            if (curso != null)
            {
                // -- Inicio el curso Usuario
                CursoUsuarioLogic.IniciarCursoUsuario(curso.EntityID);

                diapositivasCurso = diapositivasCurso.OrderBy(x => x.Orden).ToList();

                // -- Armo url imagen para mostrar
                string imagenPath = "";

                string appPath = HttpContext.Server.MapPath(ImagenesPath);
                string folderPath = appPath;

                // -- Si existe imagen para diapositva
                if (diapositivasCurso.First().Imagen != null && System.IO.File.Exists(folderPath + diapositivasCurso.First().Imagen))
                {
                    imagenPath = ImagenesPath + diapositivasCurso.First().Imagen;
                    imagenPath = imagenPath.Substring(1, imagenPath.Length - 1);
                }
                // -- Si existe imagen para curso
                else if (diapositivasCurso.First().Curso.Imagen != null && System.IO.File.Exists(folderPath + diapositivasCurso.First().Curso.Imagen))
                {
                    imagenPath = ImagenesPath + diapositivasCurso.First().Curso.Imagen;
                    imagenPath = imagenPath.Substring(1, imagenPath.Length - 1);
                }
                diapositivasCurso.First().Imagen = imagenPath;

                return View(diapositivasCurso);
            }
            else
            {
                // -- Si no tiene acceso al curso
                return RedirectToAction("NoAutorizado", "Error");
            }
        }

        public ActionResult GetDiapositiva(long diapositivaID)
        {
            // -- Recupero la diapositiva
            var diapositiva = logic.GetByID(diapositivaID);

            //Guardo la diapositiva vista
            DiapositivaVistaLogic dvLogic = new DiapositivaVistaLogic();
            dvLogic.AddOrUpdate(diapositiva);

            // -- Recupero diapositivas del curso
            var diapositivas = logic.GetByCurso(diapositiva.Curso.EntityID).OrderBy(x => x.Orden).ToList();

            #region Limpio referencias circulares

            // -- Armo url imagen para mostrar
            string imagenPath = "";

            string appPath = HttpContext.Server.MapPath(ImagenesPath);
            string folderPath = appPath;

            // -- Si existe imagen para diapositva
            if (diapositiva.Imagen != null && System.IO.File.Exists(folderPath + diapositiva.Imagen))
            {
                imagenPath = ImagenesPath + diapositiva.Imagen;
                imagenPath = imagenPath.Substring(1, imagenPath.Length - 1);
            }
            // -- Si existe imagen para curso
            else if (diapositiva.Curso.Imagen != null && System.IO.File.Exists(folderPath + diapositiva.Curso.Imagen))
            {
                imagenPath = ImagenesPath + diapositiva.Curso.Imagen;
                imagenPath = imagenPath.Substring(1, imagenPath.Length - 1);
            }
            diapositiva.Imagen = imagenPath;
            // -- Le saco el curso
            diapositiva.Curso = new Curso();

            foreach (Diapositiva diapositivaA in diapositivas)
            {
                // -- Le saco el curso a cada diapositiva
                diapositivaA.Curso = new Curso();
                // -- Le saco las referidas
                diapositivaA.DiapositivasReferidas = diapositivaA.DiapositivasReferidas.Where(x => x.EntityID != diapositivaA.EntityID).ToList();
            }


            #endregion

            // -- Asigno referidas solo con entityid y titulo
            List<Diapositiva> referidas = new List<Diapositiva>();
            diapositiva.DiapositivasReferidas.ToList().ForEach(x => referidas.Add(new Diapositiva { EntityID = x.EntityID, Titulo = x.Titulo }));
            diapositiva.DiapositivasReferidas = referidas;

            // -- Recupero el indice de la diapositiva
            var index = diapositivas.FindIndex(x => x.EntityID == diapositiva.EntityID);

            Diapositiva diapositivaAnterior = null;
            Diapositiva diapositivaSiguiente = null;
            // -- Asigno diapositiva anterior si no es la primera
            if (index != 0)
            {
                diapositivaAnterior = diapositivas[index - 1];
                diapositivaAnterior.DiapositivasReferidas = new List<Diapositiva>();
            }
            // -- Asigno diapositiva siguiente si no es la ultima
            if (index != diapositivas.Count - 1)
            {
                diapositivaSiguiente = diapositivas[index + 1];
                diapositivaSiguiente.DiapositivasReferidas = new List<Diapositiva>();
            }

            return Json(new { Diapositiva = diapositiva, DiapositivaAnterior = diapositivaAnterior, DiapositivaSiguiente = diapositivaSiguiente }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveAudio()
        {
            return View();
        }
    }
}