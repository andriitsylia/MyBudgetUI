using Microsoft.AspNetCore.Components;
using System;

namespace MyBudgetUI.Pages.Summary
{
    public class SummaryBase : ComponentBase
    {
        public DateTime Date { get; set; } = DateTime.Today;
        public DateTime BeginDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;

    }
}
