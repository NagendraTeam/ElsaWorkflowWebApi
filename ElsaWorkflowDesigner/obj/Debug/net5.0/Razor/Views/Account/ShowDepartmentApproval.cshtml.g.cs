#pragma checksum "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "345aedf1f9494947796e5e869e36b5ef4cf62f64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ShowDepartmentApproval), @"mvc.1.0.view", @"/Views/Account/ShowDepartmentApproval.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"345aedf1f9494947796e5e869e36b5ef4cf62f64", @"/Views/Account/ShowDepartmentApproval.cshtml")]
    #nullable restore
    public class Views_Account_ShowDepartmentApproval : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElsaWorkflowDesigner.ViewModel.DepartmentApprovalHistory>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<style>\r\n    th {\r\n        padding: 30px;\r\n        padding-left: 50px;\r\n    }\r\n\r\n    td {\r\n        padding: 30px;\r\n        padding-left: 50px\r\n    }\r\n</style>\r\n\r\n<h2>Approval Notification</h2>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 23 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
       Write(Html.DisplayNameFor(model => model.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 26 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
       Write(Html.DisplayNameFor(model => model.RequestedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 29 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
       Write(Html.DisplayNameFor(model => model.BudgetType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 32 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 35 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 40 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
           Write(Html.DisplayFor(modelItem => item.Workflowid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
           Write(Html.DisplayFor(modelItem => item.RequestedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
           Write(Html.DisplayFor(modelItem => item.BudgetType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
           Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n");
#nullable restore
#line 57 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
                 if(item.Status == 1) {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
           Write(Html.Raw("<span style='color:green'>Approved</span>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
                                                                      
                }
                else if(item.Status == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1602, "\"", 1618, 1);
#nullable restore
#line 62 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
WriteAttributeValue("", 1609, item.url, 1609, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">Pending..</a>\r\n");
#nullable restore
#line 63 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
                }
                else if(item.Status == 2){
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
           Write(Html.Raw("<span style='color:red'>Rejected</span>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
                                                                    
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 71 "C:\Users\u1134162\source\repos\ElsaWorkflowDesigner\ElsaWorkflowDesigner\Views\Account\ShowDepartmentApproval.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElsaWorkflowDesigner.ViewModel.DepartmentApprovalHistory>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591