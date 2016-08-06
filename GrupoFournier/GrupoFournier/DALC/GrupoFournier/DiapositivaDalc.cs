using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.GrupoFournier
{
    public class DiapositivaDalc : DalcBase<Diapositiva>
    {
        /// <summary>
        /// Recupera diapositvas por curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public List<Diapositiva> GetByCurso(long idCurso)
        {
            return Session.QueryOver<Diapositiva>().Where(x => x.Curso.EntityID == idCurso).List().ToList();
        }

        /// <summary>
        /// Recupera diapositiva por curso y orden
        /// </summary>
        /// <param name="idCurso"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        public Diapositiva GetByCursoYOrden(long idCurso, int orden)
        {
            return Session.QueryOver<Diapositiva>().Where(x => x.Curso.EntityID == idCurso && x.Orden == orden).List().FirstOrDefault();
        }

        public override Diapositiva GetByID(long ID)
        {
            // -- Recupera entidad
            return Session.QueryOver<Diapositiva>().Where(x => x.Curso.EntityID > 0 && x.EntityID == ID).List().FirstOrDefault();
        }
    }
}
