using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC
{
    public class EmpresaDalc : DalcBase<Empresa>
    {
        /// <summary>
        /// Agrega una empresa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override long Add(Empresa entity)
        {
            return base.Add(entity);
        }

        /// <summary>
        /// Actualiza una empresa
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Empresa entity)
        {
            base.Update(entity);
        }

        /// <summary>
        /// Borra una empresa
        /// </summary>
        /// <param name="ID"></param>
        public override void Delete(long ID)
        {
            base.Delete(ID);
        }

        /// <summary>
        ///  Borra logicamente una empresa
        /// </summary>
        /// <param name="entity"></param>
        public override void LogicDelete(Empresa entity)
        {
            base.LogicDelete(entity);
        }

        /// <summary>
        /// Recupera empresas activas
        /// </summary>
        /// <returns></returns>
        public override List<Empresa> GetAllActivos()
        {
            return base.GetAllActivos();
        }

        /// <summary>
        /// Recupera empresa por id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public override Empresa GetByID(long ID)
        {
            return base.GetByID(ID);
        }
    }
}
