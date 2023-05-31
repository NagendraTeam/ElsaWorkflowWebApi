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
using Elsa.Activities.Email;
using Elsa.Activities.ControlFlow;
using NodaTime;
using Elsa.Activities.Http.Extensions;
using Elsa.Activities.Temporal;

namespace ElsaWorkflowDesigner.Workflows
{
    public class ApprovalCFOWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            //  builder
            //   //.SetVariable("Document", context => context.Input.ToString())
            //   .HttpEndpoint(activity => activity
            //      .WithPath("/DepartmentBudgetApprovalCFO")
            //      .WithMethod(HttpMethod.Post.Method)
            //      .WithReadContent())
            //   .SetVariable("Document", context => context.GetInput<HttpRequestModel>()!.Body)
            //   .WriteHttpResponse(activity => activity
            //   .WithContent(context =>
            //   {
            //       var approvalUrl = "";
            //       var rejectUrl = "";
            //       approvalUrl = "https://localhost:44370/workflow/Approval?workflowid=" + context.GetVariable<dynamic>("Document")!.Workflowid + "&flowcount=" + context.GetVariable<dynamic>("Document")!.flowcount +
            //       "&deptname=" + context.GetVariable<dynamic>("Document")!.deptname + "&ApproverEmail=" + context.GetVariable<dynamic>("Document")!.ApproverEmail + "&ReqestedBy=" + context.GetVariable<dynamic>("Document")!.RequestedBy +
            //       "&deptid=" + 3;
            //       rejectUrl = "https://localhost:44370/workflow/Reject?workflowid=" + context.GetVariable<dynamic>("Document")!.Workflowid + "&flowcount=" + context.GetVariable<dynamic>("Document")!.flowcount +
            //       "&deptname=" + context.GetVariable<dynamic>("Document")!.deptname + "&ApproverEmail=" + context.GetVariable<dynamic>("Document")!.ApproverEmail + "&ReqestedBy=" + context.GetVariable<dynamic>("Document")!.RequestedBy +
            //       "&deptid=" + 3;

            //       return "<script> function accept() { window.close();window.open('" + approvalUrl + "') } " +
            //       "function reject() { window.close();window.open('" + rejectUrl + "') } </script>" +
            //       "<h1>" + context.GetVariable<dynamic>("Document")!.Content + "</h1>" +
            //       "<p>Approver Name: " + context.GetVariable<dynamic>("Document")!.ApproverBy + "</p>" +
            //       "<p>Approver Emailid: " + context.GetVariable<dynamic>("Document")!.ApproverEmail + "</p>" +
            //       "<p>Requested Name: " + context.GetVariable<dynamic>("Document")!.RequestedBy + "</p>" +
            //       "<p>Bugdet Type: adHoc</p>" +
            //       "<p>Amount: " + context.GetVariable<dynamic>("Document")!.Amount + "</p>" +
            //       "<button style='color:Green' onclick=accept()>Accept?</button> &nbsp&nbsp&nbsp&nbsp&nbsp" +
            //       "<button style='color:Red' onclick=reject()>Reject?</button>";
            //   })
            //   .WithContentType("text/html")
            //   .WithStatusCode(HttpStatusCode.OK).WithResponseHeaders(new HttpResponseHeaders { ["X-Powered-By"] = "Elsa Workflows" })
            //);
            _ = builder
                 .WithDisplayName("Document Approval Workflow")
                 .HttpEndpoint(activity => activity
                     .WithPath("/DepartmentBudgetApprovalCFO")
                     .WithMethod(HttpMethod.Post.Method)
                     .WithReadContent())
                 .SetVariable("Document", context => context.GetInput<HttpRequestModel>()!.Body)
                 .SendEmail(activity => activity
                     .WithSender("Nagendrafact@gmail.com")
                     .WithRecipient("Nagendramark8@gmail.com")
                     .WithSubject(context => $"Document received from {context.GetVariable<dynamic>("Document")!.Author.Name}")
                     .WithBody(context =>
                     {
                         var document = context.GetVariable<dynamic>("Document")!;
                         var author = document!.Author;
                         return $"Document from {author.Name} received for review.<br><a href=\"{context.GenerateSignalUrl("Approve")}\">Approve</a> or <a href=\"{context.GenerateSignalUrl("Reject")}\">Reject</a>";
                     }))
                 .WriteHttpResponse(
                     HttpStatusCode.OK,
                     "<h1>Request for Approval Sent</h1><p>Your document has been received and will be reviewed shortly.</p>",
                     "text/html")
                 .Then<Fork>(activity => activity.WithBranches("Approve", "Reject", "Remind"), fork =>
                 {
                     fork
                         .When("Approve")
                         .SignalReceived("Approve")
                         .SendEmail(activity => activity
                             .WithSender("Nagendrafact@gmail.com")
                             .WithRecipient(context => context.GetVariable<dynamic>("Document")!.Author.Email)
                             .WithSubject(context => $"Document {context.GetVariable<dynamic>("Document")!.Id} Approved!")
                             .WithBody(context => $"Great job {context.GetVariable<dynamic>("Document")!.Author.Name}, that document is perfect."))
                         .ThenNamed("Join");

                     fork
                         .When("Reject")
                         .SignalReceived("Reject")
                         .SendEmail(activity => activity
                             .WithSender("Nagendrafact@gmail.com")
                             .WithRecipient(context => context.GetVariable<dynamic>("Document")!.Author.Email)
                             .WithSubject(context => $"Document {context.GetVariable<dynamic>("Document")!.Id} Rejected")
                             .WithBody(context => $"Nice try {context.GetVariable<dynamic>("Document")!.Author.Name}, but that document needs work."))
                         .ThenNamed("Join");

                     fork
                         .When("Remind")
                         .Timer(Duration.FromSeconds(10)).WithName("Reminder")
                         .SendEmail(activity => activity
                                 .WithSender("Nagendrafact@gmail.com")
                                 .WithRecipient("Nagendramark8@gmail.com")
                                 .WithSubject(context => $"{context.GetVariable<dynamic>("Document")!.Author.Name} is waiting for your review!")
                                 .WithBody(context =>
                                     $"Don't forget to review document {context.GetVariable<dynamic>("Document")!.Id}.<br><a href=\"{context.GenerateSignalUrl("Approve")}\">Approve</a> or <a href=\"{context.GenerateSignalUrl("Reject")}\">Reject</a>"))
                             .ThenNamed("Reminder");
                 })
                 .Add<Join>(join => join.WithMode(Join.JoinMode.WaitAny)).WithName("Join")
                 .WriteHttpResponse(HttpStatusCode.OK, "Thanks for the hard work!", "text/html");
        }
    }
}
