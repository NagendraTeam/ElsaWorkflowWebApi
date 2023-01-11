using Elsa.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace ElsaWorkflowDesigner.Services
{
    public interface IDepartmentApprovalInvoker
    {
        Task<IEnumerable<CollectedWorkflow>> DispatchWorkflowsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<CollectedWorkflow>> ExecuteWorkflowsAsync(CancellationToken cancellationToken = default);
    }
}
