using ElsaWorkflowDesigner.DataAccessLayer;
using ElsaWorkflowDesigner.Models;
using ElsaWorkflowDesigner.ViewModel;
using Esprima.Ast;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace ElsaWorkflowDesigner.Controllers
{
    public class AccountController : Controller
    {
        WorkflowElsaDataLayer wel = new WorkflowElsaDataLayer();
        public IActionResult Index()
        {
            ViewBag.deptList = getDeptList();
            return View();
        }
        [HttpPost]
        public IActionResult ShowDepartmentApproval(DepartmentLoginModel deptName)
        {
            List<DepartmentApprovalHistory> history = new List<DepartmentApprovalHistory>();
            ViewBag.deptList = getDeptList();
            var deptData = wel.getDeptApprovalList(deptName.AppoverID.Split('-')[0].Trim().ToString());
            deptData.ForEach(d =>
            {
                var data = (JObject)JsonConvert.DeserializeObject(d.WorkflowData);
                string budgetType = data.SelectToken("BudgetType").Value<string>();
                int amount = Convert.ToInt32(data.SelectToken("Amount").Value<string>());
                var his = new DepartmentApprovalHistory
                {
                    Workflowid = d.Workflowid,
                    RequestedBy = d.RequestedBy,
                    BudgetType = budgetType,
                    Amount = amount,
                    Status = d.Status,
                    url =  d.url
                };
                history.Add(his);
            });
            return View(history);
        }
        public List<DepartmentList> getDeptList()
        {
            List<DepartmentList> result = new List<DepartmentList>();
            var dept1 = new DepartmentList
            {
                id = 1,
                name = "jack29 - Radiology"
            };
            result.Add(dept1);
            var dept2 = new DepartmentList
            {
                id = 1,
                name = "raghu29 - Finance"
            };
            result.Add(dept2);
            var dept3 = new DepartmentList
            {
                id = 1,
                name = "loki10 - CFO"
            };
            result.Add(dept3);
            var dept4 = new DepartmentList
            {
                id = 1,
                name = "pooja09 - HR"
            };
            result.Add(dept4);
            return result;
        }

    }
}
