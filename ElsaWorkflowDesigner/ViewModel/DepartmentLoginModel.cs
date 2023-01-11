using System.ComponentModel.DataAnnotations;

namespace ElsaWorkflowDesigner.ViewModel
{
    public class DepartmentLoginModel
    {
        [Required]
        [Display(Name = "Appover ID")]
        public string AppoverID { get; set; }

    }
}
