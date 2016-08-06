using Cross.Common;
using DALC;
using Entities;
using Fwk.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC.GrupoFournier;

namespace Logic
{
    public class CursoUsuarioLogic : LogicBase<CursoUsuario, CursoUsuarioDalc>
    {
        /// <summary>
        /// Recupera cursousuario por curso y usuario logueado
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public CursoUsuario GetByCursoID(long cursoID)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupera curso usuario
            var cursoUsuario = Dalc.GetByUsuarioAndCurso(usuarioLogueado.EntityID, cursoID);

            return cursoUsuario;
        }
        /// <summary>
        /// Inicia el curso para un usuario
        /// </summary>
        /// <param name="cursoID">id de curso</param>
        public void IniciarCursoUsuario(long cursoID)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupera curso usuario
            var cursoUsuario = Dalc.GetByUsuarioAndCurso(usuarioLogueado.EntityID, cursoID);
            // -- Si no se inicia el curso
            if (cursoUsuario == null)
            {
                // -- Creo curso usuario y asigno propiedades
                cursoUsuario = new CursoUsuario { Activo = true };
                cursoUsuario.Usuario = new Usuario { EntityID = usuarioLogueado.EntityID };
                cursoUsuario.Curso = new Curso { EntityID = cursoID };
                cursoUsuario.EstadoCurso = new EstadoCurso { EntityID = (int)Entities.EstadoCurso.EstadosCursos.Iniciado };

                // -- Agrego curso usuario
                Dalc.Add(cursoUsuario);
            }
        }

        /// <summary>
        /// Valida si el curso fue iniciado para el usuario
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public bool CursoIniciado(long cursoID)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupera curso usuario
            var cursoUsuario = Dalc.GetByUsuarioAndCurso(usuarioLogueado.EntityID, cursoID);

            if (cursoUsuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Actualiza el estado de un cursousuario
        /// </summary>
        /// <param name="cursoUsuarioID">id del cursousuario</param>
        /// <param name="estadoID">id del nuevo estado</param>
        public void ActualizarEstado(long cursoUsuarioID, long estadoID)
        {
            var cursoUsuario = Dalc.GetByID(cursoUsuarioID);
            cursoUsuario.EstadoCurso = new EstadoCurso { EntityID = estadoID };
            Dalc.Update(cursoUsuario);
        }

        /// <summary>
        /// Guarda examen realizado 
        /// </summary>
        /// <param name="preguntas">preguntas</param>
        /// <param name="cursoID">id del cursp</param>
        /// <returns></returns>
        public float GuardarExamenRealizado(List<Pregunta> preguntas, long cursoID)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupera curso usuario
            var cursoUsuario = Dalc.GetByUsuarioAndCurso(usuarioLogueado.EntityID, cursoID);

            // -- Recupero curso
            CursoDalc cursoDalc = new CursoDalc();
            var curso = cursoDalc.GetByID(cursoID);
            // -- Cantidad correctas
            int cantCorrectas = 0;
            // -- Por cada pregunta del curso
            foreach (Pregunta pregunta in curso.Preguntas)
            {
                // -- Obtengo la opcion correcta
                Opcion opcionCorrecta = pregunta.Opciones.Where(x => x.Correcta).First();
                // -- Obtengo la pregunta de las respondidas
                Pregunta preguntaActual = preguntas.Where(x => x.EntityID == pregunta.EntityID).First();
                // -- Si la opcion elegida es la correcta(es la unica opcion que se trae de las preguntas contestadas)
                if (opcionCorrecta.EntityID == preguntaActual.Opciones.First().EntityID)
                {
                    // -- Sumo una como correcta
                    cantCorrectas++;
                }
            }

            // Calculo la nota
            double nota = (float)cantCorrectas / (float)curso.Preguntas.Count * 100;
            // -- La paso a 2 decimales
            nota = Math.Round(nota, 2);
            // -- Actualizo cursousuario
            cursoUsuario.Nota = (float)nota;
            cursoUsuario.EstadoCurso = new EstadoCurso { EntityID = (long)Entities.EstadoCurso.EstadosCursos.EvaluacionRealizada };
            Dalc.Update(cursoUsuario);

            return (float)nota;
        }

        /// <summary>
        /// Recupera datos para reporte
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public DataTable GetForReport(long cursoID)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupero los cursosUsuarios
            var cursosUsuarios = Dalc.GetByCursoAndEmpresa(cursoID, usuarioLogueado.Empresa.EntityID);
            // -- Recupero usuarios de la empresa
            UsuarioDalc usuarioDalc = new UsuarioDalc();
            var usuariosEmpresa = usuarioDalc.GetByEmpresa(usuarioLogueado.Empresa.EntityID);


            DiapositivaVistaDalc diapositivaVistaDalc = new DiapositivaVistaDalc();

            // Recupero la cantidad de diapositivas
            int cantidadDiapositivas = new DiapositivaDalc().GetByCurso(cursoID).Count;

            // -- Creo la tabla
            DataTable tablaCursosUsuarios = new DataTable("CursosUsuarios");
            tablaCursosUsuarios.Columns.Add("usuario");
            tablaCursosUsuarios.Columns.Add("estado");
            tablaCursosUsuarios.Columns.Add("nota");
            tablaCursosUsuarios.Columns.Add("diapositivasVistas");

            foreach (CursoUsuario cursoUsuario in cursosUsuarios)
            {
                // -- Creo fila
                DataRow fila = tablaCursosUsuarios.NewRow();
                // -- Asigno datos
                fila["usuario"] = cursoUsuario.Usuario.NombreCompleto;
                fila["estado"] = cursoUsuario.EstadoCurso.Nombre;
                if (cursoUsuario.EstadoCurso.EntityID == (long)Entities.EstadoCurso.EstadosCursos.EvaluacionRealizada)
                {
                    // -- Si esta hecho asigno nota
                    fila["nota"] = cursoUsuario.Nota + "%";
                }
                else
                {
                    // -- Asigno mensaje si no esta hecho
                    fila["nota"] = "Sin Nota";
                }

                //Recupero la cantidad de diapositivas que vio el usuario
                int cantidadDiapositivasVistas = diapositivaVistaDalc.GetByUsuarioAndCurso(cursoID, cursoUsuario.Usuario.EntityID).Count;
                fila["diapositivasVistas"] = (cantidadDiapositivasVistas / cantidadDiapositivas) * 100;
                tablaCursosUsuarios.Rows.Add(fila);
            }
            // -- Filtro usuarios que no hicieron el curso
            List<Usuario> usuariosNoRealizaronCurso = usuariosEmpresa.Where(x => !cursosUsuarios.Select(y => y.Usuario.EntityID).Contains(x.EntityID)).ToList();
            // -- Recupero curso
            CursoDalc cursoDalc = new CursoDalc();
            var curso = cursoDalc.GetByID(cursoID);
            // -- Filtro los usuarios que no realizaron curso a solo los que tenian el nivel suficiente
            usuariosNoRealizaronCurso = usuariosNoRealizaronCurso.Where(x => x.Rol.Nivel >= curso.RolMinimo.Nivel).ToList();
            // -- Agrego usuario que no estan en usuariocursos
            foreach (Usuario usuario in usuariosNoRealizaronCurso)
            {
                // -- Creo fila
                DataRow fila = tablaCursosUsuarios.NewRow();
                // -- Asigno datos
                fila["usuario"] = usuario.NombreCompleto;
                fila["estado"] = "No iniciado";
                // -- Asigno mensaje si no esta hecho
                fila["nota"] = "Sin Nota";
                //Recupero la cantidad de diapositivas que vio el usuario
                int cantidadDiapositivasVistas = diapositivaVistaDalc.GetByUsuarioAndCurso(cursoID, usuario.EntityID).Count;
                fila["diapositivasVistas"] = (cantidadDiapositivasVistas / cantidadDiapositivas) * 100;
                tablaCursosUsuarios.Rows.Add(fila);
            }
            return tablaCursosUsuarios;
        }

        public DataTable RecuperarCertificado(long cursoID)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("codigoRespuesta");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("empresa");
            tabla.Columns.Add("curso");
            tabla.Columns.Add("imagenEmpresa");

            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);

            // -- Recupero los cursosUsuarios
            var cursoUsuario = Dalc.GetByUsuarioAndCurso(usuarioLogueado.EntityID, cursoID);

            // -- Recupero curso
            CursoDalc cursoDalc = new CursoDalc();
            var curso = cursoDalc.GetByID(cursoID);

            //creo nueva fila
            DataRow row = tabla.NewRow();
            if (cursoUsuario.EstadoCurso.EntityID == (long)Entities.EstadoCurso.EstadosCursos.EvaluacionRealizada)
            {
                //Si aprobo el curso
                if (cursoUsuario.Nota > 60)
                {
                    row["codigoRespuesta"] = 1;
                    row["nombre"] = usuarioLogueado.NombreCompleto;
                    row["empresa"] = usuarioLogueado.Empresa.Nombre;
                    row["curso"] = curso.Nombre;
                    row["imagenEmpresa"] = usuarioLogueado.Empresa.Imagen;
                }
                else
                {
                    row["codigoRespuesta"] = 2;//No aprobo el curso
                }
            }
            else
            {
                row["codigoRespuesta"] = 3;//No realizo evaluacion
            }

            tabla.Rows.Add(row);

            return tabla;
        }
    }
}
