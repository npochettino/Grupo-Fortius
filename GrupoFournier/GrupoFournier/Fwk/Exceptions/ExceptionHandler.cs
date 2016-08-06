using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Exceptions
{
    public class ExceptionHandler : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ExceptionHandler()
        {

        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="message">mensaje que genera la excepcion</param>
        public ExceptionHandler(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="message">mensaje que genera la excepcion</param>
        /// <param name="inner">excepcion capturada</param>
        public ExceptionHandler(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
