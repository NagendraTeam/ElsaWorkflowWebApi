#pragma checksum "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab93d5343a6ec03b7f70a6f596f2a5e2c7587b22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DepartmentApproval_ApprovalHistory), @"mvc.1.0.view", @"/Views/DepartmentApproval/ApprovalHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab93d5343a6ec03b7f70a6f596f2a5e2c7587b22", @"/Views/DepartmentApproval/ApprovalHistory.cshtml")]
    #nullable restore
    public class Views_DepartmentApproval_ApprovalHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElsaWorkflowDesigner.ViewModel.ApprovalHistory>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Approval History</h2>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 12 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 15 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.WorkflowActivity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 18 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.RequestedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 21 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.Approver));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 24 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 29 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 48 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\DepartmentApproval\ApprovalHistory.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElsaWorkflowDesigner.ViewModel.ApprovalHistory>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
