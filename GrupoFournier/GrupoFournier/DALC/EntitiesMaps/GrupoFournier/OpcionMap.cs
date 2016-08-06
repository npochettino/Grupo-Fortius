using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class OpcionMap : ClassMap<Opcion>
    {
        public OpcionMap()
        {
            Table("opciones");
            Id(x => x.EntityID).Column("id_opcion").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.Correcta).Column("correcta");

            //--  Curso
            References<Pregunta>(x => x.Pregunta).Column("id_pregunta").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
