using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class DiapositivaMap : ClassMap<Diapositiva>
    {
        public DiapositivaMap()
        {
            Table("diapositivas");
            Id(x => x.EntityID).Column("id_diapositiva").GeneratedBy.Identity();
            Map(x => x.Orden).Column("orden");
            Map(x => x.Titulo).Column("titulo");
            Map(x => x.Imagen).Column("imagen");
            Map(x => x.ColorTitulo).Column("colorTitulo");
            Map(x => x.Video).Column("video");
            Map(x => x.IsDiapositivaAudio).Column("isDiapositivaAudio");//true = audio, false = responsive voice
            Map(x => x.TiempoTotal).Column("segundosDuracion");//tiempo de la diapositiva en segundos

            //--  Curso
            References<Curso>(x => x.Curso).Column("id_curso").Cascade.None().LazyLoad(Laziness.Proxy);
            //--  Plantilla
            References<Plantilla>(x => x.Plantilla).Column("id_plantilla").Cascade.None().LazyLoad(Laziness.Proxy);

            // -- Diapositivas referidas
            HasManyToMany<Diapositiva>(x => x.DiapositivasReferidas).Table("diapositivas_referidas").ParentKeyColumn("id_diapositiva").ChildKeyColumn("id_diapositiva_referida").Cascade.None().LazyLoad();
            // -- Botones
            HasMany<Boton>(x => x.Botones).KeyColumn("id_diapositiva").Cascade.AllDeleteOrphan().LazyLoad();
            // -- Textos
            HasMany<Texto>(x => x.Textos).KeyColumn("id_diapositiva").Cascade.AllDeleteOrphan().LazyLoad();
        }
    }
}