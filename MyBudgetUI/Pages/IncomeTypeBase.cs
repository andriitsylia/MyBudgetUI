using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using MyBudgetUI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Pages
{
    public class IncomeTypeBase :ComponentBase
    {
        public IEnumerable<IncomeTypeModel> IncomeTypes { get; set; }

        [Inject]
        public IIncomeTypeService IncomeTypeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IncomeTypes = await IncomeTypeService.GetIncomeTypes();
        }




        protected IncomeTypeModel incomeType = new IncomeTypeModel();
        protected int counter = 1;

        protected void AddIncomeType()
        {
            incomeType.Id = counter++;
            //incomeTypes.Add(incomeType);
            incomeType = new();
        }

        protected async Task GetIncomeTypes()
        {
            //incomeTypes = await httpClient.GetFromJsonAsync<List<IncomeTypeModel>>("https://localhost:5001/api/expensetype");
        }
    }
}
