using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class ExpenseTypeEditBase :ComponentBase
    {
        public ExpenseTypeModel ExpenseType { get; set; } = new ExpenseTypeModel();

        [Inject]
        public IExpenseTypeService ExpenseTypeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ExpenseType = await ExpenseTypeService.GetExpenseTypeById(int.Parse(Id));
        }
    }
}
