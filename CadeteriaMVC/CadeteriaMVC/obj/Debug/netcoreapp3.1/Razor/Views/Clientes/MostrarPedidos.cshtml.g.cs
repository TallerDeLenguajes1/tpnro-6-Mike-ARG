#pragma checksum "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8215e543f768a7ebf2a7cb5aacfa724e54d97096"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clientes_MostrarPedidos), @"mvc.1.0.view", @"/Views/Clientes/MostrarPedidos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8215e543f768a7ebf2a7cb5aacfa724e54d97096", @"/Views/Clientes/MostrarPedidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2692a42f72b17635496e21622741e3945302480", @"/Views/_ViewImports.cshtml")]
    public class Views_Clientes_MostrarPedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CadeteriaMVC.Entidades.Pedido>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
   ViewData["Title"] = "Pedidos de " + ViewBag.nombre; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3>Pedidos del cadete: ");
#nullable restore
#line 5 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
                       Write(ViewBag.nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
</div>

<table class=""table"">
    <tr>
        <th>Cliente</th>
        <th>Direccion</th>
        <th>Observacion</th>
        <th>Estado</th>
        <th>Tipo</th>
        <th>Cupon</th>
        <th>Costo</th>
        <th>Cambiar Estado</th>
        <th>Modificar</th>
        <th>Eliminar</th>
    </tr>

");
#nullable restore
#line 22 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
     foreach (CadeteriaMVC.Entidades.Pedido C in Model)
    {
        CadeteriaMVC.Entidades.Cliente Cl = new RepositorioCliente().Buscar(C.Cliente);

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 26 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(Cl.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(Cl.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(C.Observacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 29 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(C.Estado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 30 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(C.TipoPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(C.TieneCupon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 32 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(C.CostoPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 33 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(Html.ActionLink("Modificar", "UpdatePedido", "Pedidos", new { id = C.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 34 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
           Write(Html.ActionLink("Eliminar", "BajaPedido", "Pedidos", new { id = C.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 36 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Clientes\MostrarPedidos.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CadeteriaMVC.Entidades.Pedido>> Html { get; private set; }
    }
}
#pragma warning restore 1591
