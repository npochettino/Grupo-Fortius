using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EstadoCurso : EntityBase
    {
        public virtual string Nombre { get; set; }

        #region Enum

        public enum EstadosCursos
        {
            NoIniciado = 1,
            Iniciado = 2,
            EvaluacionVista = 3,
            EvaluacionRealizada = 4
        }

        #endregion
    }
}
