using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.IncomeType
{
    public class IncomeTypeBase : ComponentBase
    {
        public IEnumerable<IncomeTypeModel> IncomeTypes { get; set; }

        [Inject]
        public IIncomeTypeService IncomeTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            IncomeTypes = await IncomeTypeService.GetAll();
        }

        protected async Task DeleteIncomeType(int id)
        {
            var result = await IncomeTypeService.Delete(id);

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/incometype", true);
            }
        }
    }
}
