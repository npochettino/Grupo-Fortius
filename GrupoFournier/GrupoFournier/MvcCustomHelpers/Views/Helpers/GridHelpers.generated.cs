﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
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
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using MvcCustomHelpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public class GridHelpers : System.Web.WebPages.HelperPage
    {

#line 7 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult GridButton(string action, string controller, string text, string iconClass, string buttonClass, long id)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 8 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 288), Tuple.Create("\"", 319)
, Tuple.Create(Tuple.Create("", 295), Tuple.Create("/", 295), true)

#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 296), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 296), false)
, Tuple.Create(Tuple.Create("", 307), Tuple.Create("/", 307), true)

#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 308), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 308), false)
, Tuple.Create(Tuple.Create("", 315), Tuple.Create("/", 315), true)

#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 316), Tuple.Create<System.Object, System.Int32>(id

#line default
#line hidden
, 316), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 326), Tuple.Create("\"", 346)

#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 334), Tuple.Create<System.Object, System.Int32>(buttonClass

#line default
#line hidden
, 334), false)
);

WriteLiteralTo(__razor_helper_writer, "><i");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 350), Tuple.Create("\"", 368)

#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 358), Tuple.Create<System.Object, System.Int32>(iconClass

#line default
#line hidden
, 358), false)
);

WriteLiteralTo(__razor_helper_writer, "></i>");


#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
                                                              WriteTo(__razor_helper_writer, text);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span></a>\r\n");


#line 10 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 10 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 12 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult GridButtonEdit(string action, string controller, long id)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 13 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 489), Tuple.Create("\"", 520)
, Tuple.Create(Tuple.Create("", 496), Tuple.Create("/", 496), true)

#line 14 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 497), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 497), false)
, Tuple.Create(Tuple.Create("", 508), Tuple.Create("/", 508), true)

#line 14 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 509), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 509), false)
, Tuple.Create(Tuple.Create("", 516), Tuple.Create("/", 516), true)

#line 14 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 517), Tuple.Create<System.Object, System.Int32>(id

#line default
#line hidden
, 517), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-xs btn-info\"");

WriteLiteralTo(__razor_helper_writer, "><i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-pencil-square-o fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Editar</span></a>\r\n");


#line 15 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 15 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 17 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult GridButtonDelete(string action, string controller, long id)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 18 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 717), Tuple.Create("\"", 748)
, Tuple.Create(Tuple.Create("", 724), Tuple.Create("/", 724), true)

#line 19 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 725), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 725), false)
, Tuple.Create(Tuple.Create("", 736), Tuple.Create("/", 736), true)

#line 19 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 737), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 737), false)
, Tuple.Create(Tuple.Create("", 744), Tuple.Create("/", 744), true)

#line 19 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 745), Tuple.Create<System.Object, System.Int32>(id

#line default
#line hidden
, 745), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-xs btn-danger\"");

WriteLiteralTo(__razor_helper_writer, "><i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-trash fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Borrar</span></a>\r\n");


#line 20 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 20 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 22 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult GridColumnIconText(string text, string iconClass)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 23 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 
    

#line default
#line hidden

#line 24 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
WriteTo(__razor_helper_writer, text);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "<i");

WriteLiteralTo(__razor_helper_writer, " style=\"margin-left:5px\"");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 979), Tuple.Create("\"", 997)

#line 24 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 987), Tuple.Create<System.Object, System.Int32>(iconClass

#line default
#line hidden
, 987), false)
);

WriteLiteralTo(__razor_helper_writer, "></i>\r\n");


#line 25 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 25 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 27 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult GridColumnIcon(string iconClass)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 28 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <i");

WriteLiteralTo(__razor_helper_writer, " style=\"margin-left:5px\"");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 1116), Tuple.Create("\"", 1134)

#line 29 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1124), Tuple.Create<System.Object, System.Int32>(iconClass

#line default
#line hidden
, 1124), false)
);

WriteLiteralTo(__razor_helper_writer, "></i>\r\n");


#line 30 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 30 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 31 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult GridButtonModalDisable(long id, string name)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 32 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteLiteralTo(__razor_helper_writer, " href=\"#\"");

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-xs btn-danger\"");

WriteAttributeTo(__razor_helper_writer, "onclick", Tuple.Create(" onclick=\"", 1253), Tuple.Create("\"", 1286)
, Tuple.Create(Tuple.Create("", 1263), Tuple.Create("AbreModal(", 1263), true)

#line 33 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1273), Tuple.Create<System.Object, System.Int32>(id

#line default
#line hidden
, 1273), false)
, Tuple.Create(Tuple.Create("", 1276), Tuple.Create(",", 1276), true)
, Tuple.Create(Tuple.Create(" ", 1277), Tuple.Create("\'", 1278), true)

#line 33 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1279), Tuple.Create<System.Object, System.Int32>(name

#line default
#line hidden
, 1279), false)
, Tuple.Create(Tuple.Create("", 1284), Tuple.Create("\')", 1284), true)
);

WriteLiteralTo(__razor_helper_writer, "><i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-ban fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Deshabilitar</span></a>\r\n");


#line 34 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 34 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 36 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult GridColumnWithBackGround(string contenido, string color)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 37 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <span");

WriteAttributeTo(__razor_helper_writer, "style", Tuple.Create(" style=\"", 1489), Tuple.Create("\"", 1520)
, Tuple.Create(Tuple.Create("", 1497), Tuple.Create("background-color:", 1497), true)

#line 38 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1514), Tuple.Create<System.Object, System.Int32>(color

#line default
#line hidden
, 1514), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 38 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
            WriteTo(__razor_helper_writer, contenido);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span>\r\n");


#line 39 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 39 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 41 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult ModalDeshabilitar(string titulo)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 42 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <div");

WriteLiteralTo(__razor_helper_writer, " id=\"modalDeshabilitar\"");

WriteLiteralTo(__razor_helper_writer, " class=\"modal fade\"");

WriteLiteralTo(__razor_helper_writer, " role=\"dialog\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n        <div");

WriteLiteralTo(__razor_helper_writer, " class=\"modal-dialog\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n            <div");

WriteLiteralTo(__razor_helper_writer, " class=\"modal-content\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                <div");

WriteLiteralTo(__razor_helper_writer, " class=\"modal-header\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                    <button");

WriteLiteralTo(__razor_helper_writer, " type=\"button\"");

WriteLiteralTo(__razor_helper_writer, " class=\"close\"");

WriteLiteralTo(__razor_helper_writer, " data-dismiss=\"modal\"");

WriteLiteralTo(__razor_helper_writer, " aria-label=\"Close\"");

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " aria-hidden=\"true\"");

WriteLiteralTo(__razor_helper_writer, ">&times;</span></button>\r\n                    <h4");

WriteLiteralTo(__razor_helper_writer, " class=\"modal-title\"");

WriteLiteralTo(__razor_helper_writer, ">");


#line 48 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
              WriteTo(__razor_helper_writer, titulo);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</h4>\r\n                </div>\r\n                <div");

WriteLiteralTo(__razor_helper_writer, " class=\"modal-body\"");

WriteLiteralTo(__razor_helper_writer, " id=\"modal-body-deshabilitar\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                    <p></p>\r\n                </div>\r\n                <div");

WriteLiteralTo(__razor_helper_writer, " class=\"modal-footer\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                    <button");

WriteLiteralTo(__razor_helper_writer, " type=\"button\"");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-default pull-left\"");

WriteLiteralTo(__razor_helper_writer, " data-dismiss=\"modal\"");

WriteLiteralTo(__razor_helper_writer, ">Cerrar</button>\r\n                    <button");

WriteLiteralTo(__razor_helper_writer, " type=\"button\"");

WriteLiteralTo(__razor_helper_writer, " id=\"buttonDeshabilitar\"");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-danger\"");

WriteLiteralTo(__razor_helper_writer, ">Deshabilitar</button>\r\n                </div>\r\n            </div><!-- /.modal-co" +
"ntent -->\r\n        </div><!-- /.modal-dialog -->\r\n    </div>\r\n");


#line 60 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"


#line default
#line hidden
});

#line 60 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 62 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult DisplaySioNo(bool value)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 63 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 
    if (value)
    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <span>Si</span>\r\n");


#line 67 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
    }
    else
    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <span>No</span>\r\n");


#line 71 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
    }


#line default
#line hidden
});

#line 72 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

#line 73 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
public static System.Web.WebPages.HelperResult FechaSinHora(DateTime fechaYHora)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 74 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
 
    fechaYHora.ToString("dd/MM/yyyy");


#line default
#line hidden
});

#line 76 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\GridHelpers.cshtml"
}
#line default
#line hidden

    }
}
#pragma warning restore 1591
