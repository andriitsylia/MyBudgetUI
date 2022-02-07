using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class IncomeBase : ComponentBase
    {
        public IEnumerable<IncomeModel> Incomes { get; set; }

        [Inject]
        public IIncomeService IncomeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Incomes = await IncomeService.GetIncomes();
        }

    }
}
