using ElsaWorkflowDesigner.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace ElsaWorkflowDesigner.Controllers
{
    public class ApproverController : Controller
    {
        WorkflowElsaDataLayer wedl = new WorkflowElsaDataLayer();
        public IActionResult Index(string workflowid, string empid)
        {
            wedl.workflowProcess(workflowid, 1, empid, 0);

            return View();
        }
    }
}
