using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.GrupoFournier;

namespace DALC
{
    public class CursoDalc : DalcBase<Curso>
    {
        public bool FilePathDisponible(string filePath)
        {
            var cursos = Session.QueryOver<Curso>().Where(x => x.FilesFolder == filePath).List().ToList();
            if (cursos.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void BorrarCurso(Curso curso, List<Pregunta> preguntas, List<CursoUsuario> cursosUsuarios, List<EmpresaCurso> empresasCursos, List<Diapositiva> diapositivas, List<DiapositivaVista> diapositivasVistas)
        {
            using (var transaction = Session.BeginTransaction())
            {
                // -- Borro preguntas (con sus opciones)
                foreach(Pregunta pregunta in preguntas)
                {
                    Session.Delete(pregunta);
                }

                // -- Borro cursos usuarios
                foreach(CursoUsuario cu in cursosUsuarios)
                {
                    Session.Delete(cu);
                }

                // -- Borro cursos empresas
                foreach(EmpresaCurso ec in empresasCursos)
                {
                    Session.Delete(ec);
                }
                // -- Borro diapositivas
                foreach (Diapositiva diapositiva in diapositivas)
                {
                    Session.Delete(diapositiva);
                }

                //Borro las diapostivias vistas
                foreach (DiapositivaVista dv in diapositivasVistas)
                {
                    Session.Delete(dv);
                }

                // -- Borro curso
                Session.Delete(curso);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Recupera los cursos creados por la empresa
        /// </summary>
        /// <param name="empresaID"></param>
        /// <returns></returns>
        public List<Curso> GetByCreadoEmpresa(long empresaID)
        {
            var cursos = Session.QueryOver<Curso>().Where(x => x.Empresa != null && x.Empresa.EntityID == empresaID).List().ToList();
            return cursos;
        }
    }
}
