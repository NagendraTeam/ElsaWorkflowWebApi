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

namespace ElsaWorkflowDesigner.Workflows
{
    public class SampleCustomeWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
               .HttpEndpoint("/hello-world1")
               //.SetVariable("Document", context => context.Input.ToString())
               .SetVariable("Document", "Radiology")
               .WriteHttpResponse(activity => activity
               .WithContent(context => "<h1>Request for Approval Sent</h1><p>Your document has been received and will be reviewed shortly.</p><h1>" + context.GetVariable<dynamic>("Document") + "</h1>")
               .WithContentType("text/html")
               .WithStatusCode(HttpStatusCode.OK).WithResponseHeaders(new HttpResponseHeaders { ["X-Powered-By"] = "Elsa Workflows" })
           );
        }
    }
}
