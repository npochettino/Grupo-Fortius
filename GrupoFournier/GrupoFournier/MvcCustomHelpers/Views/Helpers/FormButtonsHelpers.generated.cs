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
    public class FormButtonsHelpers : System.Web.WebPages.HelperPage
    {

#line 7 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonAdd(string action, string controller)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 8 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 234), Tuple.Create("\"", 261)
, Tuple.Create(Tuple.Create("", 241), Tuple.Create("/", 241), true)

#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 242), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 242), false)
, Tuple.Create(Tuple.Create("", 253), Tuple.Create("/", 253), true)

#line 9 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 254), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 254), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-success\"");

WriteLiteralTo(__razor_helper_writer, "><i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-plus-circle fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Nuevo</span></a>\r\n");


#line 10 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 10 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 12 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonBackToList(string action, string controller)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 13 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 452), Tuple.Create("\"", 479)
, Tuple.Create(Tuple.Create("", 459), Tuple.Create("/", 459), true)

#line 14 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 460), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 460), false)
, Tuple.Create(Tuple.Create("", 471), Tuple.Create("/", 471), true)

#line 14 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 472), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 472), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-danger\"");

WriteLiteralTo(__razor_helper_writer, "><i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-arrow-circle-left fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Volver a la lista</span></a>\r\n");


#line 15 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 15 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 17 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonBackToList(string controller)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 18 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 672), Tuple.Create("\"", 691)
, Tuple.Create(Tuple.Create("", 679), Tuple.Create("/", 679), true)

#line 19 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 680), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 680), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-danger\"");

WriteLiteralTo(__razor_helper_writer, "><i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-arrow-circle-left fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Volver a la lista</span></a>\r\n");


#line 20 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 20 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 22 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonPostSave()
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 23 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <button");

WriteLiteralTo(__razor_helper_writer, " type=\"submit\"");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-success\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n        <i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-floppy-o fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Guardar\r\n    </button>\r\n");


#line 27 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 27 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 29 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonPostDelete()
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 30 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <button");

WriteLiteralTo(__razor_helper_writer, " type=\"submit\"");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-success\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n        <i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-trash fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Borrar\r\n    </button>\r\n");


#line 34 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 34 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 37 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonSubmit(string text, string iconClass)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 38 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <button");

WriteLiteralTo(__razor_helper_writer, " type=\"submit\"");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-primary\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n        <i");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 1288), Tuple.Create("\"", 1306)

#line 40 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1296), Tuple.Create<System.Object, System.Int32>(iconClass

#line default
#line hidden
, 1296), false)
);

WriteLiteralTo(__razor_helper_writer, "></i>");


#line 40 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
    WriteTo(__razor_helper_writer, text);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n    </button>\r\n");


#line 42 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 42 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 45 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonCalcelar(string action, string controller)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 46 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 1430), Tuple.Create("\"", 1457)
, Tuple.Create(Tuple.Create("", 1437), Tuple.Create("/", 1437), true)

#line 47 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1438), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 1438), false)
, Tuple.Create(Tuple.Create("", 1449), Tuple.Create("/", 1449), true)

#line 47 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1450), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 1450), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteLiteralTo(__razor_helper_writer, " class=\"btn btn-danger\"");

WriteLiteralTo(__razor_helper_writer, "><i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-arrow-circle-left fa-fw\"");

WriteLiteralTo(__razor_helper_writer, "></i>Cancelar</span></a>\r\n");


#line 48 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 48 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 51 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult ButtonGeneric(string action, string controller, string text, string iconClass, string buttonClass)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 52 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 1696), Tuple.Create("\"", 1724)
, Tuple.Create(Tuple.Create("", 1703), Tuple.Create("/", 1703), true)

#line 53 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1704), Tuple.Create<System.Object, System.Int32>(controller

#line default
#line hidden
, 1704), false)
, Tuple.Create(Tuple.Create("", 1715), Tuple.Create("/", 1715), true)

#line 53 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1716), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 1716), false)
, Tuple.Create(Tuple.Create("", 1723), Tuple.Create("/", 1723), true)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 1731), Tuple.Create("\"", 1751)

#line 53 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1739), Tuple.Create<System.Object, System.Int32>(buttonClass

#line default
#line hidden
, 1739), false)
);

WriteLiteralTo(__razor_helper_writer, "><i");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 1755), Tuple.Create("\"", 1773)

#line 53 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1763), Tuple.Create<System.Object, System.Int32>(iconClass

#line default
#line hidden
, 1763), false)
);

WriteLiteralTo(__razor_helper_writer, "></i>");


#line 53 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
                                                           WriteTo(__razor_helper_writer, text);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span></a>\r\n");


#line 54 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 54 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 57 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult ButtonGenericForAjax(string text, string iconClass, string buttonClass, string ID)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 58 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <a");

WriteAttributeTo(__razor_helper_writer, "id", Tuple.Create(" id=", 1930), Tuple.Create("", 1937)

#line 59 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1934), Tuple.Create<System.Object, System.Int32>(ID

#line default
#line hidden
, 1934), false)
);

WriteAttributeTo(__razor_helper_writer, "name", Tuple.Create(" name=", 1937), Tuple.Create("", 1946)

#line 59 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1943), Tuple.Create<System.Object, System.Int32>(ID

#line default
#line hidden
, 1943), false)
);

WriteLiteralTo(__razor_helper_writer, "><span");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 1952), Tuple.Create("\"", 1972)

#line 59 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1960), Tuple.Create<System.Object, System.Int32>(buttonClass

#line default
#line hidden
, 1960), false)
);

WriteLiteralTo(__razor_helper_writer, "><i");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 1976), Tuple.Create("\"", 1994)

#line 59 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 1984), Tuple.Create<System.Object, System.Int32>(iconClass

#line default
#line hidden
, 1984), false)
);

WriteLiteralTo(__razor_helper_writer, "></i>");


#line 59 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
                                              WriteTo(__razor_helper_writer, text);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span></a>\r\n");


#line 60 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 60 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

#line 63 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
public static System.Web.WebPages.HelperResult FormButtonSubmitCustom(string text, string iconClass, string buttonClass)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 64 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
 


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <button");

WriteLiteralTo(__razor_helper_writer, " type=\"submit\"");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 2161), Tuple.Create("\"", 2181)

#line 65 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 2169), Tuple.Create<System.Object, System.Int32>(buttonClass

#line default
#line hidden
, 2169), false)
);

WriteLiteralTo(__razor_helper_writer, ">\r\n        <i");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 2195), Tuple.Create("\"", 2213)

#line 66 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 2203), Tuple.Create<System.Object, System.Int32>(iconClass

#line default
#line hidden
, 2203), false)
);

WriteLiteralTo(__razor_helper_writer, "></i>");


#line 66 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
    WriteTo(__razor_helper_writer, text);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n    </button>\r\n");


#line 68 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"


#line default
#line hidden
});

#line 68 "C:\ProyectoMVCBase\ProyectoBase\MvcCustomHelpers\Views\Helpers\FormButtonsHelpers.cshtml"
}
#line default
#line hidden

    }
}
#pragma warning restore 1591
