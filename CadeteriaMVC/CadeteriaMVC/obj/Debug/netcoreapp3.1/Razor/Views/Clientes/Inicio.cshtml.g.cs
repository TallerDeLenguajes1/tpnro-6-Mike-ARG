#pragma checksum "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\Inicio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1ac574e29ca703c0a9485caf44a9ff09eec1107"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clientes_Inicio), @"mvc.1.0.view", @"/Views/Clientes/Inicio.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\_ViewImports.cshtml"
using CadeteriaMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\_ViewImports.cshtml"
using CadeteriaMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1ac574e29ca703c0a9485caf44a9ff09eec1107", @"/Views/Clientes/Inicio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2692a42f72b17635496e21622741e3945302480", @"/Views/_ViewImports.cshtml")]
    public class Views_Clientes_Inicio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CadeteriaMVC.ViewModel.ClienteViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\Inicio.cshtml"
   ViewData["Title"] = "Inicio";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>¡Bienvenido, ");
#nullable restore
#line 4 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\Inicio.cshtml"
            Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 127, "\"", 168, 2);
            WriteAttributeValue("", 134, "/Clientes/MostrarPedidos/", 134, 25, true);
#nullable restore
#line 6 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\Inicio.cshtml"
WriteAttributeValue("", 159, Model.ID, 159, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-lg active\" role=\"button\" aria-pressed=\"true\">Ver mis pedidos</a>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CadeteriaMVC.ViewModel.ClienteViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
