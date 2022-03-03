using Microsoft.AspNetCore.Components;
using System;

namespace MyBudgetUI.Pages.OnDateSummary
{
    public class OnDateSummaryBase : ComponentBase
    {
        [Parameter]
        public string Date { get; set; }
    }

}
