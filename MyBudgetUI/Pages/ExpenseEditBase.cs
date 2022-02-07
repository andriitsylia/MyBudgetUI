using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class ExpenseEditBase : ComponentBase
    {
        public ExpenseModel Expense { get; set; } = new ExpenseModel() { ExpenseType = new ExpenseTypeModel() };

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Expense = await ExpenseService.GetExpenseById(int.Parse(Id));
        }
    }
}
