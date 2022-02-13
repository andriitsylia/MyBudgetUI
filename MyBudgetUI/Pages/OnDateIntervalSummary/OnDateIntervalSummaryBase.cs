using Microsoft.AspNetCore.Components;

namespace MyBudgetUI.Pages.OnDateIntervalSummary
{
    public class OnDateIntervalSummaryBase : ComponentBase
    {
        [Parameter]
        public string BeginDate { get; set; }

        [Parameter]
        public string EndDate { get; set; }

    }

}
