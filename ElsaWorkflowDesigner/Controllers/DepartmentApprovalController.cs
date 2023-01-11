using Elsa.Server.Api.Endpoints.Activities;
using ElsaWorkflowDesigner.Activities;
using ElsaWorkflowDesigner.DataAccessLayer;
using ElsaWorkflowDesigner.Models;
using ElsaWorkflowDesigner.Services;
using ElsaWorkflowDesigner.ViewModel;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaWorkflowDesigner.Controllers
{
    public class DepartmentApprovalController : Controller
    {
        WorkflowElsaDataLayer wedl = new WorkflowElsaDataLayer();
        List<ApprovalHistory> result = new List<ApprovalHistory>();
        public IActionResult Index(string data, string url)
        {
            WorkflowResult result = new WorkflowResult();
            ViewBag.content = data;
            // return RedirectToAction("Index", "WorkflowOutput" , new { data = result });
            return View();
        }

        [HttpPost]
        public IActionResult getDepartmentId(string empid)
        {
            int deptid = wedl.getDepartmentId(empid);
            return Ok(deptid);
        }

        [HttpGet]
        public IActionResult ApprovalHistory(string workflowid)
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

        public int getDepartmentData()
        {
            string id = null;
            int deptid = 0;
            try
            {
                id = HttpContext.Session.GetString("budgetid") ?? "";
                deptid = wedl.getDepartmentId(id);
            }
            catch (Exception ex)
            {
                return 0;
            }
           
            
            return deptid;
        }

        [HttpPost]
        public string getDepartmentName(string workflowid)
        {
            string deptname = wedl.getDepartmentName(workflowid);
            return deptname;
        }
        
        [HttpPost]
        public string getGetApproverEmail(string budgetid)
        {
            string email = wedl.getGetApproverEmail(budgetid);
            return email;
        }
        [HttpPost]
        public string workflowUrl(string workflowid)
        {
            string types = wedl.runWorkFlow(workflowid);
            string url = "https://localhost:44370/" + types.Split(',')[0];
            return url;
        }

        [HttpPost]
        public string getNextWorkFlow(string workflowid, string workflow)
        {
            string next = wedl.getNextWorkFlow(workflowid,workflow);
            return next;
        }

    }
}
