using System.ComponentModel.DataAnnotations;

namespace MyBudgetUI.Models
{
    public class IncomeTypeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Comment is too long")]
        public string Comment { get; set; }
    }
}
