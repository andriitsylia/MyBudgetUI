using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class ExpenseBase :ComponentBase
    {
        public IEnumerable<ExpenseModel> Expenses { get; set; }

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Expenses = await ExpenseService.GetExpenses();
        }
    }
}
