using Elsa.Activities.Http;
using Elsa.Builders;
using System.Net;

namespace ElsaWorkflowDesigner.Workflows
{
    public class ApprovalFromDepartmentBudgetApproverWF : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
               .WriteHttpResponse(HttpStatusCode.OK, "<h1>Executed Department Budget Approver approved your request</h1>", "text/html");
        }
    }
}
