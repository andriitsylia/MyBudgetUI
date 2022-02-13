using System;
using System.Collections.Generic;

namespace MyBudgetUI.Models
{
    public class IncomeTotalOnDateIntervalModel
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Total { get; set; }
        public IEnumerable<IncomeModel> Incomes { get; set; }
    }
}
