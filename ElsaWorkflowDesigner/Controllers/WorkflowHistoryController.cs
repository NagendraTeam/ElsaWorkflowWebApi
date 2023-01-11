using Elsa.Activities.Workflows.Workflow;
using ElsaWorkflowDesigner.DataAccessLayer;
using ElsaWorkflowDesigner.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElsaWorkflowDesigner.Controllers
{
    public class WorkflowHistoryController : Controller
    {
        WorkflowElsaDataLayer wedl = new WorkflowElsaDataLayer();
        List<ApprovalHistory> result = new List<ApprovalHistory>();
        public IActionResult Index(string workflowid)
        {
            var data = wedl.getApprovalHistory(workflowid);

            data.ForEach(x =>
            {
                var res = new ApprovalHistory
                {
                    Workflowid = x.Workflowid,
                    Approver = x.Approver,
                    RequestedBy = x.RequestedBy,
                    status = x.status,
                    WorkflowActivity = x.WorkflowActivity
                };
                result.Add(res);

            });
            return View(result);
        }
    }
}
