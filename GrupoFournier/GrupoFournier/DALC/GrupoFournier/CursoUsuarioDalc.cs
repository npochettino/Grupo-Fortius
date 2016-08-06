using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC
{
    public class CursoUsuarioDalc : DalcBase<CursoUsuario>
    {
        /// <summary>
        /// Recupera curso para el usuario
        /// </summary>
        /// <param name="usuarioID">id usuario</param>
        /// <param name="cursoID">id curso</param>
        /// <returns></returns>
        public CursoUsuario GetByUsuarioAndCurso(long usuarioID, long cursoID)
        {
            return Session.QueryOver<CursoUsuario>().Where(x => x.Curso.EntityID == cursoID && x.Usuario.EntityID == usuarioID).List().FirstOrDefault();
        }

        /// <summary>
        /// Recupera CursosUsuarios para usuarios de una empresa y un curso
        /// </summary>
        /// <param name="cursoID"></param>
        /// <param name="empresaID"></param>
        /// <returns></returns>
        public List<CursoUsuario> GetByCursoAndEmpresa(long cursoID, long empresaID)
        {
            // -- Recupero usuarios de la empresa
            var usuariosEmpresa= Session.QueryOver<Usuario>().Where(x=>x.Empresa.EntityID==empresaID).List().ToList();
            // -- Tomo los ids de la empresa
            List<long> usuariosIDs= usuariosEmpresa.Select(x=>x.EntityID).ToList();
            // -- Devuelvo los cursosUsuarios para los usuarios y curso
            return Session.QueryOver<CursoUsuario>().Where(x => x.Curso.EntityID == cursoID).AndRestrictionOn(x => x.Usuario.EntityID).IsIn(usuariosIDs).List().ToList();
        }
        
        /// <summary>
        /// Recupera cursosUsuarios por curso
        /// </summary>
        /// <param name="cursoID"></param>
        /// <returns></returns>
        public List<CursoUsuario> GetByCurso(long cursoID)
        {
            return Session.QueryOver<CursoUsuario>().Where(x => x.Curso.EntityID == cursoID).List().ToList();
        }
    }
}
