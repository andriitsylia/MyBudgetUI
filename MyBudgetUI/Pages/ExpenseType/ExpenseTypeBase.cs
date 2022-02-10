using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.ExpenseType
{
    public class ExpenseTypeBase : ComponentBase
    {
        public IEnumerable<ExpenseTypeModel> ExpenseTypes { get; set; }

        [Inject]
        public IExpenseTypeService ExpenseTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            ExpenseTypes = await ExpenseTypeService.GetAll();
        }

        protected async Task DeleteExpenseType(int id)
        {
            var result = await ExpenseTypeService.Delete(id);
           
            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expensetype", true);
            }
        }

    }
}
