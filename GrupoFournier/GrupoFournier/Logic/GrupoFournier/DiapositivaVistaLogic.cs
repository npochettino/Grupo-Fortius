using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cross.Common;
using DALC;
using DALC.GrupoFournier;
using Entities;
using Entities.GrupoFournier;
using Fwk.Session;
using Logic;

namespace Logic.GrupoFournier
{
    public class DiapositivaVistaLogic : LogicBase<DiapositivaVista, DiapositivaVistaDalc>
    {
        /// <summary>
        /// Inserta una nueva diapositiva vista si no existe, o actualiza la fecha si existe
        /// </summary>
        /// <param name="diapositivaID"></param>
        public void AddOrUpdate(Diapositiva diapositiva)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);

            DiapositivaVista dv = Dalc.GetByUsuarioAndDiapositiva(diapositiva.EntityID, usuarioLogueado.EntityID);

            //si no exista la diapositiva vista creo una nueva
            if (dv == null)
            {
                dv = new DiapositivaVista();
                DiapositivaDalc diapositivaDalc = new DiapositivaDalc();

                //asigno diapositiva y usuario
                dv.Diapositiva = diapositiva;

                dv.Usuario = usuarioLogueado;
                //actualizo la fecha vista
                dv.FechaHoraVista = DateTime.Now;

                Dalc.Add(dv);
            }
            else
            {
                //actualizo la fecha vista
                dv.FechaHoraVista = DateTime.Now;

                Dalc.Update(dv);
            }
        }
    }
}
