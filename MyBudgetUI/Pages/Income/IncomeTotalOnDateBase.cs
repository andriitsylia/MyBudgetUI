using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.Income
{
    public class IncomeTotalOnDateBase : ComponentBase
    {
        public IncomeTotalOnDateModel IncomeTotalOnDate { get; set; }

        [Inject]
        public IIncomeService IncomeService { get; set; }

        [Parameter]
        public string Date { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            IncomeTotalOnDate = await IncomeService.GetOnDate(DateTime.Parse(Date));
        }
    }
}
