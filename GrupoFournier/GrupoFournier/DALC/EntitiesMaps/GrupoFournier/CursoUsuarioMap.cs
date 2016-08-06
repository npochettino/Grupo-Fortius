using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC.EntitiesMaps
{
    public class CursoUsuarioMap : ClassMap<CursoUsuario>
    {
        public CursoUsuarioMap()
        {
            Table("cursos_usuarios");
            Id(x => x.EntityID).Column("id_cursousuario").GeneratedBy.Identity();
            Map(x => x.Activo).Column("activo");
            Map(x => x.Nota).Column("nota");

            //--  Curso
            References<Curso>(x => x.Curso).Column("id_curso").Cascade.None().LazyLoad(Laziness.Proxy);
            //--  Usuario
            References<Usuario>(x => x.Usuario).Column("id_usuario").Cascade.None().LazyLoad(Laziness.Proxy);
            //--  Estado Curso
            References<EstadoCurso>(x => x.EstadoCurso).Column("id_estadocurso").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
