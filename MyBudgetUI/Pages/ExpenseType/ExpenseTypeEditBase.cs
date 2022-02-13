using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.ExpenseType
{
    public class ExpenseTypeEditBase : ComponentBase
    {
        public ExpenseTypeModel ExpenseType { get; set; } = new ExpenseTypeModel();

        [Inject]
        public IExpenseTypeService ExpenseTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public string PageHeader { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int expenseTypeId);
            if (expenseTypeId > 0)
            {
                PageHeader = "Редактирование типа расхода";
                ExpenseType = await ExpenseTypeService.GetById(expenseTypeId);
            }
            else
            {
                PageHeader = "Создание типа расхода";
                ExpenseType = new();
            }
        }

        protected async Task SaveExpenseType()
        {
            HttpResponseMessage result;

            if (ExpenseType.Id != 0)
            {
                result = await ExpenseTypeService.Update(ExpenseType);
            }
            else
            {
                result = await ExpenseTypeService.Create(ExpenseType);
            }

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expensetype");
            }
        }

        protected async Task DeleteExpenseType()
        {
            var result = await ExpenseTypeService.Delete(ExpenseType.Id);

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expensetype", true);
            }
        }

    }
}
