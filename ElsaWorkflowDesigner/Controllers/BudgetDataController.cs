using ElsaWorkflowDesigner.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElsaWorkflowDesigner.Controllers
{
    public class BudgetDataController : Controller
    {
        [HttpGet]
        public IActionResult insertDocumentBudgetApproval(string budgetid, string empid, string workflowid)
        {
            WorkflowElsaDataLayer wedl = new WorkflowElsaDataLayer();
            //HttpContext.Session.SetString("budgetid", budgetid);
            wedl.insertDepartmentApprovalData(budgetid ,empid, workflowid);
            return Ok();
        }
    }
}
