#pragma checksum "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7e921eea571b987b191132dd83de8b78769013b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedidos_Index), @"mvc.1.0.view", @"/Views/Pedidos/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7e921eea571b987b191132dd83de8b78769013b", @"/Views/Pedidos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2692a42f72b17635496e21622741e3945302480", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedidos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CadeteriaMVC.ViewModel.PedidoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
   ViewData["Title"] = "Lista de pedidos";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<a class=""btn btn-primary"" href=""/Cadetes/Inicio"" role=""button"">Página de inicio Cadete</a>
<br />
<br />
<a class=""btn btn-primary"" href=""/Clientes/Inicio"" role=""button"">Página de inicio Cliente</a>

<div class=""text-center"">
    <h3>Listado de Pedidos</h3>
</div>

<table class=""table"">
    <tr>
        <th>Número de pedido</th>
        <th>Pedido</th>
        <th>Cliente</th>
        <th>Cadete</th>
        <th>Tipo de pedido</th>
        <th>Estado</th>
        <th>Cupón</th>
        <th>Valor del pedido</th>
        <th>Modificar pedido</th>
        <th>Cancelar pedido</th>
    </tr>

");
#nullable restore
#line 27 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
     foreach (CadeteriaMVC.ViewModel.PedidoViewModel P in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 30 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
           Write(P.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
           Write(P.Observacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 32 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
           Write(P.Cliente);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 33 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
           Write(P.Cadete);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 34 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
           Write(P.TipoPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 35 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
           Write(P.Estado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 36 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
               if (P.TieneCupon == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Sí</td>\r\n");
#nullable restore
#line 39 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>No</td>\r\n");
#nullable restore
#line 43 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 45 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
           Write(P.CostoPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 46 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
              
                if (P.Estado != CadeteriaMVC.Entidades.Estado.Entregado)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 49 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
                   Write(Html.ActionLink("Modificar pedido", "UpdatePedido", new { id = P.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 50 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
                   Write(Html.ActionLink("Cancelar pedido", "BajaPedido", new { id = P.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 54 "C:\RepoGit2\tp6\CadeteriaMVC\CadeteriaMVC\Views\Pedidos\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CadeteriaMVC.ViewModel.PedidoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
