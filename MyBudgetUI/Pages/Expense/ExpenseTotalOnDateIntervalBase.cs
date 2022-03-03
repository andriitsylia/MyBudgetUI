using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.Expense
{
    public class ExpenseTotalOnDateIntervalBase : ComponentBase
    {
        public ExpenseTotalOnDateIntervalModel ExpenseTotalOnDateInterval { get; set; }

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        [Parameter]
        public string BeginDate { get; set; }

        [Parameter]
        public string EndDate { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            ExpenseTotalOnDateInterval = await ExpenseService.GetOnDateInterval(
                DateTime.ParseExact(BeginDate, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact(EndDate, "dd.MM.yyyy", CultureInfo.InvariantCulture));
        }
    }
}
