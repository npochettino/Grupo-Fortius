using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC
{
    public class EmpresaCursoDalc : DalcBase<EmpresaCurso>
    {
        /// <summary>
        /// Recuperar EmpresasCursos por curso
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public List<EmpresaCurso> GetByCurso(long cursoID)
        {
            return Session.QueryOver<EmpresaCurso>().Where(x => x.Curso.EntityID == cursoID).List().ToList();
        }
    }
}
