#pragma checksum "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Finance\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c18a3c961c561707f6298d1ed2f4066254c5835"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Finance_Index), @"mvc.1.0.view", @"/Views/Finance/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c18a3c961c561707f6298d1ed2f4066254c5835", @"/Views/Finance/Index.cshtml")]
    #nullable restore
    public class Views_Finance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.3/jquery.min.js"" integrity=""sha512-STof4xm1wgkfm7heWqFJVn58Hm3EtS31XFaagaa8VMReCXAkQnJZ+jEy8PCC/iT18dFy95WcExNHFTqLyp72eQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
<script>
    $(document).ready(function () {
        var jsonObject =
            {
                ""Id"": ""1"",
                ""Author"":
                {
                    ""Name"": ""John"",
                    ""Email"": ""john@gmail.com""
                },
                ""Body"": ""This is sample document."",
                ""Input"": ""Hello"",
                ""DepartmentName"": ""Finance"",
                ""ReqestedBy"": '',
                ""Approver"": ""Ram70"",
                ""Workflow"": 'DepartmentBudgetApprovalFinance',
                ""Workflowid"": ''
            };
        $.ajax({
            url: ""https://localhost:44370/"" + 'DepartmentBudgetApprovalFinance',
            type: ""POST"",
            dataType: ""json"",
            data: JSON.st");
            WriteLiteral(@"ringify(jsonObject),
            contentType: ""application/json; charset=utf-8"",
            success: function (response) {
                alert(response.responseText);
            },
            error: function (response) {

                const winHtml = response.responseText;
                const winUrl = URL.createObjectURL(
                    new Blob([winHtml], { type: ""text/html"" })
                );
                const win = window.open(
                    winUrl,
                    ""win"",
                    `width=800,height=400,screenX=200,screenY=200`
                );
            }
        });
    });
</script>

<label id=""name""></label>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
