using System;
using System.Collections.Generic;

namespace MyBudgetUI.Models
{
    public class IncomeTotalOnDateModel
    {
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public IEnumerable<IncomeModel> Incomes { get; set; }
    }
}
