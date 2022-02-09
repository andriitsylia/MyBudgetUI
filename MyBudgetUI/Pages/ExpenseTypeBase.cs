using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class ExpenseTypeBase : ComponentBase
    {
        public IEnumerable<ExpenseTypeModel> ExpenseTypes { get; set; }

        [Inject]
        public IExpenseTypeService ExpenseTypeService { get; set; }

        public int Counter { get; set; } = 1;

        protected override async Task OnInitializedAsync()
        {
            ExpenseTypes = await ExpenseTypeService.GetExpenseTypes();
        }

    }
}
