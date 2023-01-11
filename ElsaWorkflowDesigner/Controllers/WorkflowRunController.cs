using ElsaWorkflowDesigner.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElsaWorkflowDesigner.Controllers
{
    public class WorkflowRunController : ControllerBase
    {
        public IActionResult Index(workflowInputs inputs, string response)
        {

            return Redirect(string.Format("https://www.google.com"));
        }
    }
}
