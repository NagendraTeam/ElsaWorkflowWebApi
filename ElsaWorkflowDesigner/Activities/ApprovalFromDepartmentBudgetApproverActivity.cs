using Elsa.Activities.Http;
using Elsa.Activities.Workflows;
using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using Elsa.Services.Workflows;
using ElsaWorkflowDesigner.Services;
using ElsaWorkflowDesigner.Workflows;
using Raven.Client.Documents.Operations.ConnectionStrings;
using System;
using System.Threading.Tasks;
using System.Threading;
using Elsa.Attributes;
using Jint.Native;
using Raven.Client.Documents.Operations.ETL.SQL;
using Elsa;
using System.Drawing;

namespace ElsaWorkflowDesigner.Activities
{
    [Activity(
    Category = "Demo",
    DisplayName = "Approval From Department Budget Approver Activity",
    Outcomes = new[] { OutcomeNames.Done }
    )]
    public class ApprovalFromDepartmentBudgetApproverActivity : Activity
    {
        public ApprovalFromDepartmentBudgetApproverActivity(IBuildsAndStartsWorkflow workflowRunner)
        {
            _workflowRunner = workflowRunner;
        }
        private readonly IBuildsAndStartsWorkflow _workflowRunner;
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {

            _workflowRunner.BuildAndStartWorkflowAsync<ApprovalDepartmentWorkflow>();
            return context.WorkflowExecutionContext.IsFirstPass ? Done() : Suspend();
        }
    }
}
