using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class PlantillaMap : ClassMap<Plantilla>
    {
        public PlantillaMap()
        {
            Table("plantillas");
            Id(x => x.EntityID).Column("id_plantilla").GeneratedBy.Identity();
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Estructura).Column("estructura");
            Map(x => x.Activo).Column("activo");
        }
    }
}
