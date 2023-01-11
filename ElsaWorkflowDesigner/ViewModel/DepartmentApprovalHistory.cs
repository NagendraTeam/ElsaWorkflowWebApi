using System.ComponentModel.DataAnnotations;

namespace ElsaWorkflowDesigner.ViewModel
{
    public class DepartmentApprovalHistory
    {
        [Display(Name = "Workflow Id")]
        public string Workflowid { get; set; }
        [Display(Name = "Requested By")]
        public string RequestedBy { get; set; }
        [Display(Name = "Budget Type")]
        public string BudgetType { get; set; }
        public string WorkflowData { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
        public string url { get; set; }
    }
}
