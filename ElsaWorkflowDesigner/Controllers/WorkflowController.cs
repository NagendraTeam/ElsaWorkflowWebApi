using ElsaWorkflowDesigner.DataAccessLayer;
using ElsaWorkflowDesigner.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ElsaWorkflowDesigner.Controllers
{
    public class WorkflowController : Controller
    {
        ApprovalOrReject approvalStatus = new ApprovalOrReject();
        WorkflowElsaDataLayer wedl = new WorkflowElsaDataLayer();
        public IActionResult Index(string workflowid, string workflow)
        {
            return View();
        }
        public IActionResult Approval(string workflowid, int flowcount, string deptname, string ApproverEmail, string ReqestedBy, int deptid)
        {
            wedl.insertApprovalHistory(workflowid, ReqestedBy, deptname, ApproverEmail, "Approved");
            wedl.workflowProcess(workflowid, flowcount + 1, "", deptid);
            approvalStatus.Content = "Approval got accepted from " + deptname;
            approvalStatus.WorkflowId = workflowid;
            return View(approvalStatus);
        }
        public IActionResult Reject(string workflowid, string flowcount, string deptname, string Approver, string ReqestedBy)
        {
            wedl.insertApprovalHistory(workflowid, ReqestedBy, deptname, Approver, "Rejected");
            wedl.UpdateApprovalHistory(workflowid, Convert.ToInt32(flowcount));
            approvalStatus.Content = "Approval got rejected from " + deptname;
            return View(approvalStatus);
        }
    }
}
