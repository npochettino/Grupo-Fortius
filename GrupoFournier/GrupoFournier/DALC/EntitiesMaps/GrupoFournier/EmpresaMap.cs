using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    /// <summary>
    /// Map de empresa
    /// </summary>
    public class EmpresaMap : ClassMap<Empresa>
    {
        public EmpresaMap()
        {
            Table("empresas");
            Id(x => x.EntityID).Column("id_empresa").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Imagen).Column("imagen");

            // -- Cursos asignados a empresa
            //HasManyToMany<Curso>(x => x.Cursos).Table("empresas_cursos").ParentKeyColumn("id_empresa").ChildKeyColumn("id_curso").Cascade.None().LazyLoad();

            //-- EmpresaCurso
            HasMany<EmpresaCurso>(x => x.EmpresaCursos).KeyColumn("id_empresa").Cascade.AllDeleteOrphan().LazyLoad();
        }
    }
}
