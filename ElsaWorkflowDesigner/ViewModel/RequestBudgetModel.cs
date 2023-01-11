using Fluid.Parser;
using System.ComponentModel.DataAnnotations;

namespace ElsaWorkflowDesigner.ViewModel
{
    public class RequestBudgetModel
    {

        [Required]
        [Display(Name = "Requested From")]
        public string RequestedBy { get; set; }

        [Required]
        [Display(Name = "Budget Type")]
        public string BudgetType { get; set; }

        [Required]
        public string Amount { get; set; }

        public int budgetid { get; set; }
    }
}
