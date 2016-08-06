using DALC;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EmpresaCursoLogic : LogicBase<EmpresaCurso, EmpresaCursoDalc>
    {
        /// <summary>
        /// Actualiza una empresa curso
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(EmpresaCurso entity)
        {
            // -- Recupero la empresa curso guardada
            var empresaCursoActual = Dalc.GetByID(entity.EntityID);
            entity.Curso = empresaCursoActual.Curso;
            base.Update(entity);
        }
    }
}
