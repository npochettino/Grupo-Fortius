using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC
{
    public class PreguntaDalc : DalcBase<Pregunta>
    {
        /// <summary>
        ///  Recupera preguntas del curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public List<Pregunta> GetPreguntasByCurso(long idCurso)
        {
            // -- Obtengo preguntas del curso
            var preguntas = Session.QueryOver<Pregunta>().Where(x => x.Curso.EntityID == idCurso).List().ToList();
            return preguntas;
        }
    }
}
