using System.ComponentModel.DataAnnotations;

namespace ElsaWorkflowDesigner.Models
{
    public class RequestBudgetJsonData
    {
        public string RequestedBy { get; set; }

        public string BudgetType { get; set; }

        public string Amount { get; set; }
        public string serverUrl { get; set; }
        public string responseText { get; set; }
        public int deptid { get; set; }
    }
}
