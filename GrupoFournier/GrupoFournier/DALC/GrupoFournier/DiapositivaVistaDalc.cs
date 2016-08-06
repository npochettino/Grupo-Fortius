using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.GrupoFournier;
using NHibernate.Linq;

namespace DALC.GrupoFournier
{
    public class DiapositivaVistaDalc : DalcBase<DiapositivaVista>
    {
        public DiapositivaVista GetByUsuarioAndDiapositiva(long diapositivaID, long usuarioID)
        {
            DiapositivaVista dv = Session.QueryOver<DiapositivaVista>().Where(x => x.Diapositiva.EntityID == diapositivaID && x.Usuario.EntityID == usuarioID).SingleOrDefault();
            return dv;
        }

        public List<DiapositivaVista> GetByDiapositiva(long diapositivaID)
        {
            List<DiapositivaVista> dv = Session.QueryOver<DiapositivaVista>().Where(x => x.Diapositiva.EntityID == diapositivaID).List().ToList();
            return dv;
        }

        public List<DiapositivaVista> GetByUsuarioAndCurso(long cursoID, long usuarioID)
        {
            List<DiapositivaVista> dv = Session.Query<DiapositivaVista>().Where(x => x.Diapositiva.Curso.EntityID == cursoID && x.Usuario.EntityID == usuarioID).ToList();
            return dv;
        }
    }
}
