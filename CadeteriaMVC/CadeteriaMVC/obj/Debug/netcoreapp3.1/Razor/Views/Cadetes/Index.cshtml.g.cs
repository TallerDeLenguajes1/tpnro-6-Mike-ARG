#pragma checksum "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b599f9ed7b24ee8357a4a4c0a451b23e8a3f7ed1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadetes_Index), @"mvc.1.0.view", @"/Views/Cadetes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b599f9ed7b24ee8357a4a4c0a451b23e8a3f7ed1", @"/Views/Cadetes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2692a42f72b17635496e21622741e3945302480", @"/Views/_ViewImports.cshtml")]
    public class Views_Cadetes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CadeteriaMVC.ViewModel.CadeteViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
   ViewData["Title"] = "Cadetes";

    RepositorioCadete R = new RepositorioCadete();


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<a class=""btn btn-primary"" href=""AltaCadete"" role=""button"">Crear Cadete</a>

<div class=""text-center"">
    <h3>Listado de cadetes</h3>
</div>

<table class=""table"">
    <tr>
        <th>Nombre</th>
        <th>Direccion</th>
        <th>Telefono</th>
        <th>Vehiculo</th>
        <th>Jornal</th>
        <th>Pedidos</th>
        <th>Modificar</th>
        <th>Eliminar</th>
    </tr>

");
#nullable restore
#line 26 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
     foreach (CadeteriaMVC.ViewModel.CadeteViewModel C in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 29 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(C.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 30 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(C.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(C.Telefono);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 32 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(C.TipoVehiculo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 33 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(R.CalcularJornal(C.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 34 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(Html.ActionLink("Ver pedidos", "MostrarPedidos", new { id = C.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 35 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(Html.ActionLink("Modificar", "UpdateCadete", new { id = C.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 36 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
           Write(Html.ActionLink("Eliminar", "BajaCadete", new { id = C.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 38 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Cadetes\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CadeteriaMVC.ViewModel.CadeteViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
