using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MyBudgetUI.Pages
{
    public class ExpenseEditBase : ComponentBase
    {
        public ExpenseModel Expense { get; set; } = new ExpenseModel() { ExpenseType = new ExpenseTypeModel() };

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        public IEnumerable<ExpenseTypeModel> ExpenseTypes { get; set; } = new List<ExpenseTypeModel>();

        [Inject]
        public IExpenseTypeService ExpenseTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Expense = await ExpenseService.GetExpenseById(int.Parse(Id));
            ExpenseTypes = (await ExpenseTypeService.GetExpenseTypes()).OrderBy(o => o.Name);
        }

        protected async Task SaveExpense()
        {
            var result = await ExpenseService.UpdateExpense(Expense);
            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expense");
            }
        }
    }
}
