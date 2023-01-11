using Elsa.Services;
using ElsaWorkflowDesigner.Activities;
using ElsaWorkflowDesigner.Implementation;
using ElsaWorkflowDesigner.Workflows;
using System.Collections.Generic;

namespace ElsaWorkflowDesigner.Services
{
    public class DepartmentBudgetBookmarkProvider : BookmarkProvider<DepartmentBudgetBookmark, DepartmentBudgetApproval>
    {
        public override IEnumerable<BookmarkResult> GetBookmarks(BookmarkProviderContext<DepartmentBudgetApproval> context)
        {
            return new[] { Result(new DepartmentBudgetBookmark()) };
        }
    }
}
