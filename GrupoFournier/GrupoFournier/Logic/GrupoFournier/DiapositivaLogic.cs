using DALC.GrupoFournier;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DiapositivaLogic : LogicBase<Diapositiva, DiapositivaDalc>
    {
        /// <summary>
        /// Recupera diapositvas de un curso
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public List<Diapositiva> GetByCurso(long cursoID)
        {
            return Dalc.GetByCurso(cursoID);
        }

        /// <summary>
        /// Recupera diapositiva por curso y orden
        /// </summary>
        /// <param name="idCurso"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        public Diapositiva GetByOrdenYCurso(long cursoID, int orden)
        {
            return Dalc.GetByCursoYOrden(cursoID, orden);
        }

        public override Diapositiva GetByID(long ID)
        {
            return base.GetByID(ID);
        }
    }
}
