using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.Income
{
    public class IncomeTotalOnDateIntervalBase : ComponentBase
    {
        public IncomeTotalOnDateIntervalModel IncomeTotalOnDateInterval { get; set; }

        [Inject]
        public IIncomeService IncomeService { get; set; }

        [Parameter]
        public string BeginDate { get; set; }

        [Parameter]
        public string EndDate { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            IncomeTotalOnDateInterval = await IncomeService.GetOnDateInterval(DateTime.Parse(BeginDate), DateTime.Parse(EndDate));
        }
    }
}
