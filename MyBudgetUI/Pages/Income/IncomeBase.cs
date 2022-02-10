using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.Income
{
    public class IncomeBase : ComponentBase
    {
        public IEnumerable<IncomeModel> Incomes { get; set; }

        [Inject]
        public IIncomeService IncomeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            Incomes = await IncomeService.GetAll();
        }

        protected async Task DeleteIncome(int id)
        {
            var result = await IncomeService.Delete(id);

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/income", true);
            }
        }

    }
}
