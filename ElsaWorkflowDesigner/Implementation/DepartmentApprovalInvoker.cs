using Elsa.Services.Models;
using Elsa.Services;
using ElsaWorkflowDesigner.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using ElsaWorkflowDesigner.Activities;

namespace ElsaWorkflowDesigner.Implementation
{
    public class DepartmentApprovalInvoker : IDepartmentApprovalInvoker
    {
        private readonly IWorkflowLaunchpad _workflowLaunchpad;

        public DepartmentApprovalInvoker(IWorkflowLaunchpad workflowLaunchpad)
        {
            _workflowLaunchpad = workflowLaunchpad;
        }

        public async Task<IEnumerable<CollectedWorkflow>> DispatchWorkflowsAsync(CancellationToken cancellationToken = default)
        {
            var context = new WorkflowsQuery(nameof(DepartmentBudgetApproval), new FileReceivedBookmark());
            return await _workflowLaunchpad.CollectAndDispatchWorkflowsAsync(context, null, cancellationToken);
        }

        public async Task<IEnumerable<CollectedWorkflow>> ExecuteWorkflowsAsync(CancellationToken cancellationToken = default)
        {
            var context = new WorkflowsQuery(nameof(DepartmentBudgetApproval), new FileReceivedBookmark());
            return await _workflowLaunchpad.CollectAndExecuteWorkflowsAsync(context, null, cancellationToken);
        }
    }
}
