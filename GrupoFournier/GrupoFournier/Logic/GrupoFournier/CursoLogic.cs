using Cross.Common;
using DALC;
using DALC.GrupoFournier;
using Entities;
using Fwk.GUID;
using Fwk.Session;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.GrupoFournier;
//using System.IO.Compression;

namespace Logic
{
    public class CursoLogic : LogicBase<Curso, CursoDalc>
    {
        #region CONST

        private const string ImagenesPath = "~/Imagenes/ImagenesCursos/";

        // -- El formato sería "curso" + curso.EntityID + extension
        // -- Ejemplo "curso1.jpg"
        private const string ImagenCursoPath = "curso{0}{1}";

        #endregion


        /// <summary>
        /// Agrega curso y carga archivos
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="appPath"></param>
        /// <param name="fileStream"></param>
        public void AddCurso(Curso entity, string appPath, Stream fileStream)
        {
            // -- Seteo propiedades
            entity.Activo = true;
            entity.FechaAlta = DateTime.Now;
            // -- Cargado false porque aun no se suben archivos
            entity.Cargado = false;

            // -- Itero hasta obtener guid no usado
            bool flag = true;
            while (flag)
            {
                // -- Obtengo el friendly guid
                entity.FilesFolder = GuidEncoder.Encode(Guid.NewGuid());
                // -- Obtengo si esta disponible
                bool disponible = Dalc.FilePathDisponible(entity.FilesFolder);
                if (disponible)
                {
                    // -- Cambio flag
                    flag = false;
                }
            }

            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);

            //Si el usuario no es administrador del sitio o administrador guardo la empresa
            if (usuarioLogueado.Rol.EntityID != Convert.ToInt64(Global.Roles.ADMINISTRADOR) || usuarioLogueado.Rol.EntityID != Convert.ToInt64(Global.Roles.ADMINISTRADOR_SITIO))
            {
                entity.Empresa = new EmpresaLogic().GetByID(usuarioLogueado.Empresa.EntityID);
            }

            base.Add(entity);

            //Si es diferente de null implica que el curso lo creo una empresa, por lo tanto se lo asigno directamente
            if (entity.Empresa != null)
            {
                AsignarCursoEmpresa(entity.Empresa.EntityID, entity.EntityID);
            }

            #region Creacion de carpeta y subida de archivos

            // -- Concateno 
            appPath += entity.FilesFolder;

            // -- Subida de archivos
            using (ZipFile zip = ZipFile.Read(fileStream))
            {

                // -- Creo directorio
                System.IO.Directory.CreateDirectory(appPath);
                // -- Descomprimo
                zip.ExtractAll(appPath);
            }

            // -- Actualizo el estado de subida
            entity.Cargado = true;
            Dalc.Update(entity);

            #endregion
            // -- Copiar archivos en 
        }

        /// <summary>
        /// Agrega curso y carga imagen
        /// </summary>
        /// <param name="curso"></param>
        /// <param name="appPath"></param>
        /// <param name="fileStream"></param>
        /// <param name="extension"></param>
        public void AddCurso(Curso curso, string appPath, Stream fileStream, string extension)
        {
            // -- Seteo propiedades
            curso.Activo = true;
            curso.FechaAlta = DateTime.Now;
            // -- Cargado false porque aun no se suben archivos
            curso.Cargado = false;

            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);

            //Si el usuario no es administrador del sitio o administrador guardo la empresa
            if (usuarioLogueado.Rol.EntityID != Convert.ToInt64(Global.Roles.ADMINISTRADOR) || usuarioLogueado.Rol.EntityID != Convert.ToInt64(Global.Roles.ADMINISTRADOR_SITIO))
            {
                curso.Empresa = new EmpresaLogic().GetByID(usuarioLogueado.Empresa.EntityID);
            }

            base.Add(curso);

            //Si es diferente de null implica que el curso lo creo una empresa, por lo tanto se lo asigno directamente
            if (curso.Empresa != null)
            {
                AsignarCursoEmpresa(curso.Empresa.EntityID, curso.EntityID);
            }

            #region Cargo Imagen del curso

            appPath += string.Format(ImagenCursoPath, curso.EntityID, extension);
            var length = Convert.ToInt32(fileStream.Length);

            byte[] data = null;

            using (var reader = new BinaryReader(fileStream))
            {
                data = reader.ReadBytes(length);
            }

            //-- Si existe imagen con el mismo nombre la sobreescribo
            if (File.Exists(appPath))
            {
                File.Delete(appPath);
            }

            // -- Creo imagen
            var file = new FileStream(appPath, FileMode.Create, FileAccess.Write);

            file.Write(data, 0, length);

            file.Close();

            #endregion

            // -- Asigno imagen al curso y actualizo
            curso.Imagen = string.Format(ImagenCursoPath, curso.EntityID, extension);
            Dalc.Update(curso);

        }

        /// <summary>
        /// Agrega curso sin archivos
        /// </summary>
        /// <param name="entity"></param>
        public void AddCurso(Curso entity)
        {
            // -- Seteo propiedades
            entity.Activo = true;
            entity.FechaAlta = DateTime.Now;
            // -- Cargado false porque aun no se suben archivos
            entity.Cargado = false;

            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);

            //Si el usuario no es administrador del sitio o administrador guardo la empresa
            if (usuarioLogueado.Rol.EntityID != Convert.ToInt64(Global.Roles.ADMINISTRADOR) || usuarioLogueado.Rol.EntityID != Convert.ToInt64(Global.Roles.ADMINISTRADOR_SITIO))
            {
                entity.Empresa = new EmpresaLogic().GetByID(usuarioLogueado.Empresa.EntityID);
            }

            base.Add(entity);

            //Si es diferente de null implica que el curso lo creo una empresa, por lo tanto se lo asigno directamente
            if (entity.Empresa != null)
            {
                AsignarCursoEmpresa(entity.Empresa.EntityID, entity.EntityID);
            }
        }

        /// <summary>
        /// Sube los archivos de un curso
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="appPath"></param>
        /// <param name="fileStream"></param>
        public void RecargarCurso(Curso entity, string appPath, Stream fileStream)
        {
            // -- Concateno 
            appPath += entity.FilesFolder;

            // -- Limpio directorio
            System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(appPath);
            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
            {
                dir.Delete(true);
            }

            // -- Subida de archivos
            using (ZipFile zip = ZipFile.Read(fileStream))
            {

                // -- Creo directorio
                System.IO.Directory.CreateDirectory(appPath);
                // -- Descomprimo
                zip.ExtractAll(appPath);
            }
        }

        /// <summary>
        /// Recupero cursos para el usuario logueado
        /// </summary>
        /// <returns></returns>
        public List<Curso> RecuperarCursosParaUsuarioLogueado()
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupera empresa del usuario
            EmpresaDalc empDalc = new EmpresaDalc();
            var empresa = empDalc.GetByID(usuarioLogueado.Empresa.EntityID);
            // -- Recupero cursos disponibles para usuario logueado
            var cursosEmpresa = empresa.EmpresaCursos.Where(x => x.Curso.RolMinimo.Nivel <= usuarioLogueado.Rol.Nivel && (!x.TieneLimite || x.FechaHasta > DateTime.Now)).ToList();
            return cursosEmpresa.Select(x => x.Curso).ToList();
        }

        /// <summary>
        /// Recupero curso si tiene acceso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public Curso ValidarCursoParaUsuarioLogueado(long idCurso)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupera empresa del usuario
            EmpresaDalc empDalc = new EmpresaDalc();
            var empresa = empDalc.GetByID(usuarioLogueado.Empresa.EntityID);
            // -- Recupero cursos empresa disponibles para usuario logueado
            var cursosEmpresa = empresa.EmpresaCursos.Where(x => x.Curso.RolMinimo.Nivel <= usuarioLogueado.Rol.Nivel && (!x.TieneLimite || x.FechaHasta > DateTime.Now)).ToList();
            // -- Recupero curso por id
            var cursoEmpresa = cursosEmpresa.Where(x => x.Curso.EntityID == idCurso).FirstOrDefault();
            //Retorno curso a null dependiendo si tiene acceso
            if (cursoEmpresa != null)
            {
                return cursoEmpresa.Curso;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Recupera cursos para la empresa
        /// </summary>
        /// <returns></returns>
        public List<Curso> GetByEmpresa()
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupera empresa del usuario
            EmpresaDalc empDalc = new EmpresaDalc();
            var empresa = empDalc.GetByID(usuarioLogueado.Empresa.EntityID);
            // -- Recupero cursos para empresa logueada
            List<Curso> cursos = empresa.EmpresaCursos.ToList().Select(x => x.Curso).ToList();

            return cursos;
        }

        /// <summary>
        /// Recupera cursos que creo la empresa
        /// </summary>
        /// <returns></returns>
        public List<Curso> GetByCreadoEmpresa(long empresaID)
        {
            // -- Recupero cursos creados por la empresa logueada
            List<Curso> cursos = Dalc.GetByCreadoEmpresa(empresaID);

            return cursos;
        }

        /// <summary>
        /// Borra un curso
        /// </summary>
        /// <param name="cursoID"></param>
        public void BorrarCurso(long cursoID)
        {
            // -- Obtengo curso
            var curso = Dalc.GetByID(cursoID);

            // -- Obtengo preguntas
            PreguntaDalc pregDalc = new PreguntaDalc();
            var preguntasCurso = pregDalc.GetPreguntasByCurso(cursoID);

            // -- Obtengo CursosUsuarios
            CursoUsuarioDalc cuDalc = new CursoUsuarioDalc();
            var cursosUsuarios = cuDalc.GetByCurso(cursoID);

            // -- Obtengo EmpresasCursos
            EmpresaCursoDalc ecDalc = new EmpresaCursoDalc();
            var empresasCursos = ecDalc.GetByCurso(cursoID);

            // -- Obtengo diapositivas
            DiapositivaDalc diapositivaDalc = new DiapositivaDalc();
            var diapositivas = diapositivaDalc.GetByCurso(cursoID);

            // -- Obtengo diapositivas vistas
            DiapositivaVistaDalc dvDalc = new DiapositivaVistaDalc();
            List<DiapositivaVista> diapositivasVistas = new List<DiapositivaVista>();
            foreach (var d in diapositivas)
            {
                diapositivasVistas.AddRange(dvDalc.GetByDiapositiva(d.EntityID));
            }

            Dalc.BorrarCurso(curso, preguntasCurso, cursosUsuarios, empresasCursos, diapositivas, diapositivasVistas);
        }

        /// <summary>
        /// Actualiza curso y carga imagen
        /// </summary>
        /// <param name="curso"></param>
        /// <param name="appPath"></param>
        /// <param name="fileStream"></param>
        /// <param name="extension"></param>
        public void UpdateCurso(Curso curso, string appPath, Stream fileStream, string extension)
        {
            #region Cargo Imagen del curso

            var length = Convert.ToInt32(fileStream.Length);
            byte[] data = null;

            using (var reader = new BinaryReader(fileStream))
            {
                data = reader.ReadBytes(length);
            }

            string[] extensions = { ".jpg", ".jpeg", ".png", "gif" };
            string deletePath;
            // -- Si existe la imagen la borro
            for (int i = 0; i <= 3; i++)
            {
                deletePath = appPath + string.Format(ImagenCursoPath, curso.EntityID, extensions[i]);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }
            }

            // -- Creo imagen
            appPath += string.Format(ImagenCursoPath, curso.EntityID, extension);
            var file = new FileStream(appPath, FileMode.Create, FileAccess.Write);

            file.Write(data, 0, length);

            file.Close();

            #endregion

            // -- Asigno imagen al curso y actualizo
            curso.Imagen = string.Format(ImagenCursoPath, curso.EntityID, extension);
            base.Update(curso);
        }

        /// <summary>
        /// Asigna un curso a una empresa
        /// </summary>
        private void AsignarCursoEmpresa(long empresaID, long cursoID)
        {
            EmpresaLogic empLog = new EmpresaLogic();
            var empresa = empLog.GetByID(empresaID);

            EmpresaCurso empresaCurso = new EmpresaCurso { TieneLimite = false, Activo = true };
            Curso curso = new Curso { EntityID = cursoID };
            empresaCurso.Curso = curso;
            empresa.EmpresaCursos.Add(empresaCurso);

            empLog.AsignarCursos(empresa);
        }
    }
}