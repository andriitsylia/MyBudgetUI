using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudgetUI.Models
{
    public class IncomeModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float Sum { get; set; }

        [StringLength(50, ErrorMessage = "Comment is too long")]
        public string Comment { get; set; }

        [Required]
        public int IncomeTypeId { get; set; }

        public IncomeTypeModel IncomeType { get; set; }
    }
}
