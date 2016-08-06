using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class UsuarioMap: ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            // -- Tabla que representa la entidad
            Table("usuarios");
            Id(x => x.EntityID).Column("id_usuario").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.NombreUsuario).Column("nombre_usuario");
            Map(x => x.Password).Column("password");
            Map(x => x.NombreCompleto).Column("nombre_completo");
            Map(x => x.Mail).Column("mail");
            Map(x => x.Habilitado).Column("habilitado");
            Map(x => x.IsMailCursoTerminado).Column("isMailCursoTerminado");

            //--  Rol
            References<Rol>(x => x.Rol).Column("id_rol").Cascade.None().LazyLoad(Laziness.Proxy);
            //--  Empresa
            References<Empresa>(x => x.Empresa).Column("id_empresa").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
