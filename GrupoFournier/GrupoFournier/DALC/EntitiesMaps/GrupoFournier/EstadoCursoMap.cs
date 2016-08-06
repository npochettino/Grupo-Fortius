using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class EstadoCursoMap : ClassMap<EstadoCurso>
    {
        public EstadoCursoMap()
        {
            Table("estados_cursos");
            Id(x => x.EntityID).Column("id_estadocurso").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.Nombre).Column("nombre");
        }
    }
}
