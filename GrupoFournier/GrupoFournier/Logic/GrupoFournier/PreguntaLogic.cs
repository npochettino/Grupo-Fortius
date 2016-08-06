using DALC;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PreguntaLogic: LogicBase<Pregunta, PreguntaDalc>
    {
        /// <summary>
        ///  Recupera preguntas del curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public List<Pregunta> GetPreguntasByCurso(long idCurso)
        {
            return Dalc.GetPreguntasByCurso(idCurso);
        }

        //public override void Update(Pregunta entity)
        //{
        //    // -- Obtengo pregunta existente
        //    Pregunta preguntaExistente = Dalc.GetByID(entity.EntityID);

        //    base.Update(entity);
        //}
    }
}
