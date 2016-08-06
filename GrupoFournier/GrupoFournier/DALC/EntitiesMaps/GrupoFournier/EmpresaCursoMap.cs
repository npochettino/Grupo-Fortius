using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class EmpresaCursoMap : ClassMap<EmpresaCurso>
    {
        public EmpresaCursoMap()
        {
            Table("empresas_cursos");
            Id(x => x.EntityID).Column("id_empresacurso").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.TieneLimite).Column("limite_tiempo");
            Map(x => x.FechaHasta).Column("fecha_hasta");

            //--  Curso
            References<Curso>(x => x.Curso).Column("id_curso").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
