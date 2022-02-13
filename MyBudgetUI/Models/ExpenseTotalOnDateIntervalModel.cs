using System;
using System.Collections.Generic;

namespace MyBudgetUI.Models
{
    public class ExpenseTotalOnDateIntervalModel
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Total { get; set; }
        public IEnumerable<ExpenseModel> Expenses { get; set; }
    }
}
