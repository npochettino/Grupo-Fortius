using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.Sys
{
    public class ModuleDalc : DalcBase<Module>
    {
        #region Overrides Methods

        /// <summary>
        /// Agrega un modulo
        /// </summary>
        /// <param name="entity">modulo</param>
        /// <returns>id</returns>
        public override long Add(Module entity)
        {
            return base.Add(entity);
        }

        /// <summary>
        /// Actualiza un modulo
        /// </summary>
        /// <param name="entity">modulo</param>
        public override void Update(Module entity)
        {
            base.Update(entity);
        }

        /// <summary>
        /// Borra un modulo
        /// </summary>
        /// <param name="entity">id modulo</param>
        public override void Delete(long ID)
        {
            base.Delete(ID);
        }

        /// <summary>
        /// Borra logicamente un modulo
        /// </summary>
        /// <param name="entity">modulo</param>
        public override void LogicDelete(Module entity)
        {
            base.LogicDelete(entity);
        }

        /// <summary>
        /// Obtiene modulo por id
        /// </summary>
        /// <param name="ID">id de modulo</param>
        /// <returns>modulo</returns>
        public override Module GetByID(long ID)
        {
            return base.GetByID(ID);
        }

        /// <summary>
        /// Recupera modulos activos
        /// </summary>
        /// <returns>modulos activos</returns>
        public override List<Module> GetAllActivos()
        {
            return base.GetAllActivos();
        }

        #endregion
    }
}
