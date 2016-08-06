using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DALC.EntitiesMaps
{   
    public class CursoMap : ClassMap<Curso>
    {
        public CursoMap()
        {
            Table("cursos");
            Id(x => x.EntityID).Column("id_curso").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.FilesFolder).Column("filesFolder");
            Map(x => x.FechaAlta).Column("fechaAlta");
            Map(x => x.Cargado).Column("cargado");
            Map(x => x.Html).Column("html");
            Map(x => x.Imagen).Column("imagen");

            //--  Rol
            References<Rol>(x => x.RolMinimo).Column("id_rol").Cascade.None().LazyLoad(Laziness.Proxy);
            //--  Empresa
            References<Empresa>(x => x.Empresa).Column("id_empresa").Cascade.None().LazyLoad(Laziness.Proxy);
            //-- Preguntas
            HasMany<Pregunta>(x => x.Preguntas).KeyColumn("id_curso").Cascade.None().LazyLoad().Not.KeyUpdate();
        }
    }
}
