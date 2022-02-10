using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.Expense
{
    public class ExpenseBase : ComponentBase
    {
        public IEnumerable<ExpenseModel> Expenses { get; set; }

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            Expenses = await ExpenseService.GetAll();
        }

        protected async Task Delete(int id)
        {
            var result = await ExpenseService.Delete(id);

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expense", true);
            }
        }
    }
}
