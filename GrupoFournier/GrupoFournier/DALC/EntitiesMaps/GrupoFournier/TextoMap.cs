using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class TextoMap : ClassMap<Texto>
    {
        public TextoMap()
        {
            Table("textos");
            Id(x => x.EntityID).Column("id_texto").GeneratedBy.Identity();
            Map(x => x.Contenido).Column("contenido");
            Map(x => x.Orden).Column("orden");
            Map(x => x.Audio).Column("audio");
            Map(x => x.TiempoDeArranque).Column("tiempoArranque");
        }
    }
}
