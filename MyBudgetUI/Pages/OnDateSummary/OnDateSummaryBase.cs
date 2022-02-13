using Microsoft.AspNetCore.Components;

namespace MyBudgetUI.Pages.OnDateSummary
{
    public class OnDateSummaryBase : ComponentBase
    {
        [Parameter]
        public string Date { get; set; }
    }

}
