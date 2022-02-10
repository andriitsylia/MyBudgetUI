using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages.IncomeType
{
    public class IncomeTypeEditBase : ComponentBase
    {
        public IncomeTypeModel IncomeType { get; set; } = new IncomeTypeModel();

        [Inject]
        public IIncomeTypeService IncomeTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public string PageHeader { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int IncomeTypeId);
            if (IncomeTypeId > 0)
            {
                PageHeader = "Edit income type";
                IncomeType = await IncomeTypeService.GetById(IncomeTypeId);
            }
            else
            {
                PageHeader = "Create income type";
                IncomeType = new();
            }
        }

        protected async Task SaveIncomeType()
        {
            HttpResponseMessage result;

            if (IncomeType.Id > 0)
            {
                result = await IncomeTypeService.Update(IncomeType);
            }
            else
            {
                result = await IncomeTypeService.Create(IncomeType);
            }

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/incometype");
            }
        }

        protected async Task DeleteIncomeType()
        {
            var result = await IncomeTypeService.Delete(IncomeType.Id);

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/incometype", true);
            }
        }
    }
}
