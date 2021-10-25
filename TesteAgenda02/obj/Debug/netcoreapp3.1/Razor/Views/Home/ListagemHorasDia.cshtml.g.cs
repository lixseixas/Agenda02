#pragma checksum "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf1ee07e09ca0f717f3fd632e9ca0d7acb7e8506"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ListagemHorasDia), @"mvc.1.0.view", @"/Views/Home/ListagemHorasDia.cshtml")]
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
#line 1 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\_ViewImports.cshtml"
using TesteAgenda02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\_ViewImports.cshtml"
using TesteAgenda02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf1ee07e09ca0f717f3fd632e9ca0d7acb7e8506", @"/Views/Home/ListagemHorasDia.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f173fe9f34affdf7fe0c83002e5fad2ea852a6aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ListagemHorasDia : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TesteAgenda02.Models.PesquisaAgendamentoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
  
    ViewData["Title"] = "Listagem de horas por dia";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 5 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\r\n\r\n\r\n    ");
#nullable restore
#line 10 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
Write(Html.LabelFor(model => model.DataInicial, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-5\">\r\n        ");
#nullable restore
#line 12 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
   Write(Html.EditorFor(model => model.DataInicial, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n\r\n    ");
#nullable restore
#line 16 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
Write(Html.LabelFor(model => model.DataFinal, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-5\">\r\n        ");
#nullable restore
#line 18 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
   Write(Html.EditorFor(model => model.DataFinal, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    </div>

    <br />

    <div class=""form-group"">
        <div class=""col-md-2 col-lg-offset-2"">
            <button type=""button"" id=""btnPesquisarContas"" class=""btn btn-primary"">
                Pesquisar
            </button>
        </div>
    </div>

<br />

<table class=""table"">
    <thead>
        <tr>
            <th>
                Data
            </th>
            <th>
                Total de horas
            </th>
            <th>
                Total de tarefas
            </th>
            <th>
                Média de horas
            </th>
           
            <th>
                Percentual das tarefas concluídas
            </th>
        </tr>
    </thead>
    <tbody id=""TabelaAgendamentos"">
");
#nullable restore
#line 56 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
         foreach (var item in Model.ListaAgendamentosConsolidados)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
               Write(Html.DisplayFor(modelItem => item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
               Write(Html.DisplayFor(modelItem => item.Horas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
               Write(Html.DisplayFor(modelItem => item.TotalTarefas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
               Write(Html.DisplayFor(modelItem => item.MediaHoras));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 72 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
               Write(Html.DisplayFor(modelItem => item.PercentualTarefasConcluidas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>              \r\n\r\n                \r\n            </tr>\r\n");
#nullable restore
#line 77 "E:\Projetos old-testes\C#\solid\TesteAgenda02\TesteAgenda02\Views\Home\ListagemHorasDia.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TesteAgenda02.Models.PesquisaAgendamentoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
