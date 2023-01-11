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
    DisplayName = "Department Approval Activity For CFO",
    Outcomes = new[] { OutcomeNames.Done }
    )]
    public class DepartmentBudgetApprovalCFO : Activity
    {
        public DepartmentBudgetApprovalCFO(IBuildsAndStartsWorkflow workflowRunner , RunWorkflow runWorkflow)
        {
            _workflowRunner = workflowRunner;
            _runWorkflow = runWorkflow;
        }
        private readonly IBuildsAndStartsWorkflow _workflowRunner;
        private readonly RunWorkflow _runWorkflow;
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {

            _runWorkflow.WorkflowDefinitionId = "Child";
            _runWorkflow.Name = "Child";


            _runWorkflow.ExecuteAsync(context);

            //_workflowRunner.BuildAndStartWorkflowAsync<>

            //_workflowRunner.BuildAndStartWorkflowAsync<ApprovalCFOWorkflow>();
            return context.WorkflowExecutionContext.IsFirstPass ? Done() : Suspend();
        }
    }
}