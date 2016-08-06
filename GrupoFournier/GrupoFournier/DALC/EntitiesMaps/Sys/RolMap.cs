using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class RolMap : ClassMap<Rol>
    {
        public RolMap()
        {
            Table("roles");
            Id(x => x.EntityID).Column("id_rol").GeneratedBy.Identity();
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Activo).Column("activo");
            Map(x => x.Nivel).Column("nivel");

            // -- Modulos asignados al rol
            HasManyToMany<Module>(x => x.Modulos).Table("roles_modules").ParentKeyColumn("id_rol").ChildKeyColumn("id_module").Cascade.None().LazyLoad();
        }
    }
}
