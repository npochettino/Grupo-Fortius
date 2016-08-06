using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class BotonMap : ClassMap<Boton>
    {
        public BotonMap()
        {
            Table("botones");
            Id(x => x.EntityID).Column("id_boton").GeneratedBy.Identity();
            Map(x => x.Contenido).Column("contenido");
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Color).Column("color");
            Map(x => x.Orden).Column("orden");
            Map(x => x.Audio).Column("audio");
        }
    }
}
