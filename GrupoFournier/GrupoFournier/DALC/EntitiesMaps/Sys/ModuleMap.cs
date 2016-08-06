using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class ModuleMap : ClassMap<Module>
    {
        #region Contructor

        /// <summary>
        /// Ctor
        /// </summary>
        public ModuleMap()
        {
            // -- Tabla que representa la entidad
            Table("modules");
            Id(x => x.EntityID).Column("id_module").GeneratedBy.Identity();
            Map(x => x.Name).Column("name");
            Map(x => x.Caption).Column("caption");
            Map(x => x.Action).Column("action");
            Map(x => x.Icon).Column("icon");
            Map(x => x.Description).Column("description");
            Map(x => x.Type).Column("type");
            Map(x => x.Enabled).Column("habilitado");
            Map(x => x.Activo).Column("activo");
            Map(x => x.Order).Column("orden");

            // -- Relaciones
            References(x => x.Parent).Column("id_module_parent").Cascade.None().LazyLoad(Laziness.Proxy);

            //-- Prueba hijos
            HasMany<Module>(x => x.Children).KeyColumn("id_module_parent").Cascade.None().LazyLoad().Not.KeyUpdate();
        }
        #endregion
    }
}
