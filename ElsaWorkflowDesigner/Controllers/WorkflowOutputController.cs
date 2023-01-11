using ElsaWorkflowDesigner.DataAccessLayer;
using ElsaWorkflowDesigner.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElsaWorkflowDesigner.Controllers
{
    public class WorkflowOutputController : Controller
    {
        public IActionResult Index(WorkflowResult data)
        {
            ViewBag.content = data.output;
            return View();
        }

    }
}
