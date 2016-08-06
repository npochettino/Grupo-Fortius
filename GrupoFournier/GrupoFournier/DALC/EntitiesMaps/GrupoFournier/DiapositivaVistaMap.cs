using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.GrupoFournier;
using FluentNHibernate.Mapping;

namespace DALC.EntitiesMaps.GrupoFournier
{
    public class DiapositivaVistaMap : ClassMap<DiapositivaVista>
    {
        public DiapositivaVistaMap()
        {
            Table("diapositivas_usuarios");
            Id(x => x.EntityID).Column("id_diapositiva_usuario").GeneratedBy.Identity();
            Map(x => x.FechaHoraVista).Column("fecha_hora_vista");

            //--  Diapositiva
            References<Diapositiva>(x => x.Diapositiva).Column("id_diapositiva").Cascade.None().LazyLoad(Laziness.Proxy);

            //--  Usuario
            References<Usuario>(x => x.Usuario).Column("id_usuario").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
