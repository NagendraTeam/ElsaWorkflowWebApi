using Elsa.Activities.Workflows.Workflow;
using ElsaWorkflowDesigner.DataAccessLayer;
using ElsaWorkflowDesigner.ViewModel;
using Jint.Native;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ElsaWorkflowDesigner.Controllers
{
    public class RunWorkflowController : Controller
    {
        WorkflowElsaDataLayer elsa = new WorkflowElsaDataLayer();
        public IActionResult Index(string workflowid, int flowcount, string workflow, int deptid)
        {

            ApprovalContent ac = new ApprovalContent();
            var data = elsa.getWorkflowInfo(workflowid, flowcount);
            JObject jsonData = JObject.Parse(data.WorkflowData);
            //List<dynamic> models = JsonConvert.DeserializeObject(jsonData);

            ac.ApproverEmail = data.ApproverEmail;
            ac.ApproverBy = data.ApproverBy;
            ac.Amount = "100";
            ac.Content = "Request sent to " + data.DeptName + " Department";
            ac.BudgetName = data.BudgetName;
            ac.RequestedBy = data.RequestedBy;
            ac.workflow = workflow;
            ac.flowcount = flowcount;
            ac.workflowid = workflowid;
            ac.DeptName = data.DeptName;
            return View(ac);
        }
    }
}
