using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class IncomeEditBase :ComponentBase
    {
        public IncomeModel Income { get; set; } = new IncomeModel() { IncomeType = new IncomeTypeModel() };

        [Inject]
        public IIncomeService IncomeService { get; set; }

        [Parameter]
        public string Id { get; set;}

        protected override async Task OnInitializedAsync()
        {
            Income = await IncomeService.GetIncomeById(int.Parse(Id));
        }
    }
}
