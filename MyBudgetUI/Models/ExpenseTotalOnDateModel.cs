using System;
using System.Collections.Generic;

namespace MyBudgetUI.Models
{
    public class ExpenseTotalOnDateModel
    {
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public IEnumerable<ExpenseModel> Expenses { get; set; }
    }
}
