using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DALC.EntitiesMaps
{
    public class PreguntaMap : ClassMap<Pregunta>
    {
        public PreguntaMap()
        {
            Table("preguntas");
            Id(x => x.EntityID).Column("id_pregunta").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.Titulo).Column("titulo");
            Map(x => x.Orden).Column("orden");

            //--  Curso
            References<Curso>(x => x.Curso).Column("id_curso").Cascade.None().LazyLoad(Laziness.Proxy);
            //-- Opciones
            HasMany<Opcion>(x => x.Opciones).KeyColumn("id_pregunta").Cascade.AllDeleteOrphan().LazyLoad();

        }
    }
}
