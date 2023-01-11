using ElsaWorkflowDesigner.DataAccessLayer;
using ElsaWorkflowDesigner.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static NodaTime.TimeZones.TzdbZone1970Location;
using System.Collections.Generic;
using ElsaWorkflowDesigner.Models;
using NetTopologySuite.Algorithm;
using System.Net;
using System.Reflection.Emit;

namespace ElsaWorkflowDesigner.Controllers
{
    public class HomeController : Controller
    {
        WorkflowElsaDataLayer wel = new WorkflowElsaDataLayer();
        List<BudgetType> budgetList = new List<BudgetType>();
        List<string> budgetTypes = new List<string>();
        [HttpGet]
        public IActionResult Index()
        {
            getBudgetType();
            return View();
        }
        [HttpPost]
        public IActionResult Index(RequestBudgetModel request)
        {
            getBudgetType();
            int deptid = wel.insertBudgetRequestData(request);
            request.budgetid = deptid;

            if (deptid != 0)
            {
                return RedirectToAction("Index", "Designer", new { requestedBy = request.RequestedBy, budgetid = request.budgetid });
            }
            else {
                return View();
            }
            //return RedirectToPage("/_Host");
           
           // return Redirect(string.Format(" https://localhost:44387/home/index?name=somevalue"));
           // return (string.Format("https://localhost:44387/home/index?name="));
            //return Redirect("https://localhost:44387/");
        }
        public void getBudgetType()
        {
            budgetList = wel.getBudgetTypeList();
            //budgetList.ForEach(x =>
            //{
            //    budgetTypes.Add(x.name);
            //});
            ViewBag.budgetTypes = budgetList;
        }
    }
}
