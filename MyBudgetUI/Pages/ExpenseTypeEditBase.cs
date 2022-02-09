using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class ExpenseTypeEditBase :ComponentBase
    {
        public ExpenseTypeModel ExpenseType { get; set; } = new ExpenseTypeModel();

        [Inject]
        public IExpenseTypeService ExpenseTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ExpenseType = await ExpenseTypeService.GetExpenseTypeById(int.Parse(Id));
        }

        protected async Task SaveExpenseType()
        {
            var result = await ExpenseTypeService.UpdateExpenseType(ExpenseType);
            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expensetype");
            }
        }
    }
}
