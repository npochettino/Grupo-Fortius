﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcCustomHelpers.Razor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    
    #line 6 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
    using System.Web.Mvc.Html;
    
    #line default
    #line hidden
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using MvcCustomHelpers;
    
    #line 5 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
    using MvcCustomHelpers.Classes;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public class DropDownListHelper : System.Web.WebPages.HelperPage
    {

#line 10 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
public static System.Web.WebPages.HelperResult  DropDownRol(System.Web.Mvc.HtmlHelper html, bool todos)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 11 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
 
// -- Creamos el adapter
Logic.RolLogic rolLogic = new Logic.RolLogic();

// -- Obtengo la lista
var conceptos = rolLogic.GetAllActivos();

// -- Llamo al Generador de combos
    

#line default
#line hidden

#line 19 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, DropDownBuilder(html, ControlsNames.DropDownRol, conceptos, todos, ValuesNames.Nombre, ValuesNames.ID));


#line default
#line hidden

#line 19 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                                           ;


#line default
#line hidden
});

#line 20 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
}
#line default
#line hidden

#line 23 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
public static System.Web.WebPages.HelperResult  DropDownRolInferioresEmpresa(System.Web.Mvc.HtmlHelper html, bool todos)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 24 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
 
    // -- Creamos el adapter
    Logic.RolLogic rolLogic = new Logic.RolLogic();

    // -- Obtengo la lista
    var conceptos = rolLogic.GetInferioresEmpresa();

    // -- Llamo al Generador de combos
    

#line default
#line hidden

#line 32 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, DropDownBuilder(html, ControlsNames.DropDownRol, conceptos, todos, ValuesNames.Nombre, ValuesNames.ID));


#line default
#line hidden

#line 32 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                                           ;


#line default
#line hidden
});

#line 33 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
}
#line default
#line hidden

#line 36 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
public static System.Web.WebPages.HelperResult  DropDownRolParaCursos(System.Web.Mvc.HtmlHelper html, bool todos)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 37 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
 
    // -- Creamos el adapter
    Logic.RolLogic rolLogic = new Logic.RolLogic();

    // -- Obtengo la lista
    var conceptos = rolLogic.GetRolesParaCursos();

    // -- Llamo al Generador de combos
    

#line default
#line hidden

#line 45 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, DropDownBuilder(html, ControlsNames.DropDownRol, conceptos, todos, ValuesNames.Nombre, ValuesNames.ID));


#line default
#line hidden

#line 45 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                                           ;


#line default
#line hidden
});

#line 46 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
}
#line default
#line hidden

#line 49 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
public static System.Web.WebPages.HelperResult  DropDownEmpresa(System.Web.Mvc.HtmlHelper html, bool todos)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 50 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
 
// -- Creamos la logic
Logic.EmpresaLogic empresaLogic = new Logic.EmpresaLogic();

// -- Obtengo la lista
var conceptos = empresaLogic.GetAllActivos();

// -- Llamo al Generador de combos
    

#line default
#line hidden

#line 58 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, DropDownBuilder(html, ControlsNames.DropDownEmpresa, conceptos, todos, ValuesNames.Nombre, ValuesNames.ID));


#line default
#line hidden

#line 58 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                                               ;


#line default
#line hidden
});

#line 59 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
}
#line default
#line hidden

#line 63 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
public static System.Web.WebPages.HelperResult  DropDownCursosDeEmpresa(System.Web.Mvc.HtmlHelper html, bool todos)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 64 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
 
    // -- Creamos la logic
    Logic.CursoLogic cursoLogic = new Logic.CursoLogic();

    // -- Obtengo la lista
    var conceptos = cursoLogic.GetByEmpresa();

    // -- Llamo al Generador de combos
    

#line default
#line hidden

#line 72 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, DropDownBuilder(html, ControlsNames.DropDownCurso, conceptos, todos, ValuesNames.Nombre, ValuesNames.ID));


#line default
#line hidden

#line 72 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                                             ;


#line default
#line hidden
});

#line 73 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
}
#line default
#line hidden

#line 76 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
public static System.Web.WebPages.HelperResult  DropDownPlantilla(System.Web.Mvc.HtmlHelper html, bool todos)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 77 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
 
    // -- Creamos la logic
    Logic.PlantillaLogic logic = new Logic.PlantillaLogic();

    // -- Obtengo la lista
    var conceptos = logic.GetAllActivos();

    // -- Llamo al Generador de combos
    

#line default
#line hidden

#line 85 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, DropDownBuilder(html, ControlsNames.DropDownPlantilla, conceptos, todos, ValuesNames.Nombre, ValuesNames.ID));


#line default
#line hidden

#line 85 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                                                 ;


#line default
#line hidden
});

#line 86 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
}
#line default
#line hidden

#line 89 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
public static System.Web.WebPages.HelperResult DropDownBuilder(System.Web.Mvc.HtmlHelper html, string ID, System.Collections.IList lista, bool todos, string displayMember, string valueMember)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 90 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
 
// -- Seteamos el valor seleccionado por defecto
long? selectedValue = null;

// -- Si en el ViewBag hay un selected
if (html.ViewData[string.Format("selected{0}", ID)] != null)
{

    // -- Seteo el selected
    selectedValue = Convert.ToInt64(html.ViewData[string.Format("selected{0}", ID)]);
}

// -- Convierto la lista a dropDownList
var dropDownListItems = DropDownListConvertor.ListToDropDownListItemList(lista, displayMember, valueMember);

// -- Creo la lista de select items
var listsItems = new System.Web.Mvc.SelectList(dropDownListItems, "Valor", "Texto", selectedValue);

if (todos)
{
    // -- Muestro el combo
    

#line default
#line hidden

#line 111 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, html.DropDownList(ID, listsItems, "-- TODOS --", htmlAttributes: new { @class = "form-control select2" }));


#line default
#line hidden

#line 111 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                                              
}
else
{
    // -- Muestro el combo
    

#line default
#line hidden

#line 116 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
WriteTo(__razor_helper_writer, html.DropDownList(ID, listsItems, htmlAttributes: new { @class = "form-control select2" }));


#line default
#line hidden

#line 116 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
                                                                                               
}


#line default
#line hidden
});

#line 118 "C:\Proyectos .NET\GrupoFournier\MvcCustomHelpers\Views\Helpers\DropDownListHelper.cshtml"
}
#line default
#line hidden

    }
}
#pragma warning restore 1591
