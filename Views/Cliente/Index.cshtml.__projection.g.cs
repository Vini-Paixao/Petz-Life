//------------------------------------------------------------------------------
// <auto-generated>
//     O c�digo foi gerado por uma ferramenta.
//     Vers�o de Tempo de Execu��o:4.0.30319.42000
//
//     As altera��es ao arquivo poder�o causar comportamento incorreto e ser�o perdidas se
//     o c�digo for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Index_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Index_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
  
ViewBag.Title = "�rea do Cliente -";
Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden

#line 2 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                                                   __o = Session["usuarioLogado"];


#line default
#line hidden

#line 3 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                        __o = Url.Action("DetalhesCliente", "Cliente", new { id = Session["idLogado"] });


#line default
#line hidden

#line 4 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                                    foreach (var espec in ViewBag.espec)
                                    {
                                        

#line default
#line hidden

#line 5 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                                                  __o = espec.especVeterinario;


#line default
#line hidden

#line 6 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                                                                           __o = espec.especVeterinario;


#line default
#line hidden

#line 7 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                                                                                                                
                                    }

#line default
#line hidden

#line 8 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                        __o = Url.Action("Index", "Animal", new { id = Session["idLogado"] });


#line default
#line hidden

#line 9 "C:\Users\marcu\AppData\Local\Temp\45B8C332AD5694E617BDFD5469F894075A00\2\Tcc\Views\Cliente\Index.cshtml"
                __o = Url.Action("Historico", "Cliente", new { area = "" });


#line default
#line hidden
}
}
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Index_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Index_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
  

#line default
#line hidden

#line 2 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
__o = model;


#line default
#line hidden

#line 3 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
         IEnumerable<Tcc.Models.ClinicaViewModel>
ViewBag.Title = "�rea do Cliente -";
Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden

#line 4 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                                                   __o = Session["usuarioLogado"];


#line default
#line hidden

#line 5 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                        __o = Url.Action("DetalhesCliente", "Cliente", new { id = Session["idLogado"] });


#line default
#line hidden

#line 6 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                                        foreach (var especialidades in ViewBag.espec)
                                        {
                                            

#line default
#line hidden

#line 7 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                                                      __o = especialidades.Value;


#line default
#line hidden

#line 8 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                                                                             __o = especialidades.Value;


#line default
#line hidden

#line 9 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                                                                                                                
                                        }

#line default
#line hidden

#line 10 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                        __o = Url.Action("Index", "Animal", new { id = Session["idLogado"] });


#line default
#line hidden

#line 11 "C:\Users\3bdsmod\AppData\Local\Temp\A05C55BDF74E2062EA28C098470B73B3C374\2\Tcc\Views\Cliente\Index.cshtml"
                __o = Url.Action("Historico", "Cliente", new { area = "" });


#line default
#line hidden
}
}
}