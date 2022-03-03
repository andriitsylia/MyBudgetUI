using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.Expense
{
    public class ExpenseTotalOnDateBase : ComponentBase
    {
        public ExpenseTotalOnDateModel ExpenseTotalOnDate { get; set; }

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        [Parameter]
        public string Date { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            ExpenseTotalOnDate = await ExpenseService.GetOnDate(DateTime.ParseExact(Date, "dd.MM.yyyy", CultureInfo.InvariantCulture));
        }
    }
}
