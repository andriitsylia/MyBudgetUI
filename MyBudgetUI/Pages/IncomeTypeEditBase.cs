using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class IncomeTypeEditBase :ComponentBase
    {
        public IncomeTypeModel IncomeType { get; set; } = new IncomeTypeModel();

        [Inject]
        public IIncomeTypeService IncomeTypeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IncomeType = await IncomeTypeService.GetIncomeTypeById(int.Parse(Id));
        }
    }
}
