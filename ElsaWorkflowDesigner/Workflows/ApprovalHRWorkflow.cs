using Elsa.Builders;
using Elsa.Activities.Http;
using System.Net;
using YesSql;
using ElsaWorkflowDesigner.ViewModel;
using Microsoft.AspNetCore.Http;
using ElsaWorkflowDesigner.Controllers;
using Elsa.Activities.Primitives;
using Elsa.Activities.Http.Models;
using Elsa.Activities.Console;
using System.Net.Http;
using DotLiquid;
using ElsaWorkflowDesigner.DataAccessLayer;
using static System.Net.WebRequestMethods;

namespace ElsaWorkflowDesigner.Workflows
{
    public class ApprovalHRWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
             //.SetVariable("Document", context => context.Input.ToString())
             .HttpEndpoint(activity => activity
                .WithPath("/DepartmentBudgetApprovalHR")
                .WithMethod(HttpMethod.Post.Method)
                .WithReadContent())
             .SetVariable("Document", context => context.GetInput<HttpRequestModel>()!.Body)
             .WriteHttpResponse(activity => activity
             .WithContent(context =>
             {
                 var approvalUrl = "";
                 var rejectUrl = "";
                 approvalUrl = "https://localhost:44370/workflow/Approval?workflowid=" + context.GetVariable<dynamic>("Document")!.Workflowid + "&flowcount=" + context.GetVariable<dynamic>("Document")!.flowcount +
                 "&deptname=" + context.GetVariable<dynamic>("Document")!.deptname + "&ApproverEmail=" + context.GetVariable<dynamic>("Document")!.ApproverEmail + "&ReqestedBy=" + context.GetVariable<dynamic>("Document")!.RequestedBy +
                 "&deptid=" + 4;
                 rejectUrl = "https://localhost:44370/workflow/Reject?workflowid=" + context.GetVariable<dynamic>("Document")!.Workflowid + "&flowcount=" + context.GetVariable<dynamic>("Document")!.flowcount +
                 "&deptname=" + context.GetVariable<dynamic>("Document")!.deptname + "&ApproverEmail=" + context.GetVariable<dynamic>("Document")!.ApproverEmail + "&ReqestedBy=" + context.GetVariable<dynamic>("Document")!.RequestedBy +
                 "&deptid=" + 4;

                 return "<script> function accept() { window.close();window.open('" + approvalUrl + "') } " +
                 "function reject() { window.close();window.open('" + rejectUrl + "') } </script>" +
                 "<h1>" + context.GetVariable<dynamic>("Document")!.Content + "</h1>" +
                 "<p>Approver Name: " + context.GetVariable<dynamic>("Document")!.ApproverBy + "</p>" +
                 "<p>Approver Emailid: " + context.GetVariable<dynamic>("Document")!.ApproverEmail + "</p>" +
                 "<p>Requested Name: " + context.GetVariable<dynamic>("Document")!.RequestedBy + "</p>" +
                 "<p>Bugdet Type: adHoc</p>" +
                 "<p>Amount: " + context.GetVariable<dynamic>("Document")!.Amount + "</p>" +
                 "<button style='color:Green' onclick=accept()>Accept?</button> &nbsp&nbsp&nbsp&nbsp&nbsp" +
                 "<button style='color:Red' onclick=reject()>Reject?</button>";
             })
             .WithContentType("text/html")
             .WithStatusCode(HttpStatusCode.OK).WithResponseHeaders(new HttpResponseHeaders { ["X-Powered-By"] = "Elsa Workflows" })
          );
            
        }
    }
}
