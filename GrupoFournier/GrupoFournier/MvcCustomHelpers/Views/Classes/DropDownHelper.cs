using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MvcCustomHelpers.Classes
{
    //public static class DropDownHelper
    //{
    //    /// <summary>
    //    /// Convierte una lista en un DropDownListItem
    //    /// </summary>
    //    /// <param name="list">lista a convertir</param>
    //    /// <param name="textField">texto para mostrar en el dropdown</param>
    //    /// <param name="valueField">valor en el dropdown</param>
    //    /// <returns></returns>
    //    public static List<DropDownListItem> ListToDropDownListItemList(IList list, string textField, string valueField)
    //    {
    //        // -- Transformamos la lista en DropDownListItem.
    //        List<DropDownListItem> listItems = new List<DropDownListItem>();
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            PropertyInfo pText = list[i].GetType().GetProperty(textField);
    //            PropertyInfo pValue = list[i].GetType().GetProperty(valueField);
    //            listItems.Add(new DropDownListItem() { Texto = pText.GetValue(list[i]).ToString(), Valor = Convert.ToInt64(pValue.GetValue(list[i])) });
    //        }
    //        return listItems;
    //    }
    //}
    //public class DropDownListItem
    //{
    //    #region Members

    //    private long? valor;
    //    private string texto;

    //    #endregion

    //    #region Properties
    //    /// <summary>
    //    /// Value
    //    /// </summary>
    //    public long? Valor
    //    {
    //        get
    //        {
    //            return valor;
    //        }
    //        set
    //        {
    //            valor = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Display
    //    /// </summary>
    //    public string Texto
    //    {
    //        get
    //        {
    //            return texto;
    //        }
    //        set
    //        {
    //            texto = value;
    //        }
    //    }

    //    #endregion
    //}
}