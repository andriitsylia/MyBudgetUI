using Microsoft.AspNetCore.Components;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyBudgetUI.Pages.Income
{
    public class IncomeEditBase : ComponentBase
    {
        public IncomeModel Income { get; set; } = new IncomeModel() { IncomeType = new IncomeTypeModel() };

        [Inject]
        public IIncomeService IncomeService { get; set; }

        public IEnumerable<IncomeTypeModel> IncomeTypes { get; set; } = new List<IncomeTypeModel>();

        [Inject]
        public IIncomeTypeService IncomeTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public string PageHeader { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int IncomeId);
            if (IncomeId > 0)
            {
                PageHeader = "Редактирование";
                Income = await IncomeService.GetById(IncomeId);
            }
            else
            {
                PageHeader = "Создание";
                Income = new IncomeModel() { Date = DateTime.Today, IncomeType = new IncomeTypeModel() };
            }
            IncomeTypes = (await IncomeTypeService.GetAll()).OrderBy(o => o.Name);
        }

        protected async Task SaveIncome()
        {
            HttpResponseMessage result;

            if (Income.Id > 0)
            {
                result = await IncomeService.Update(Income);
            }
            else
            {
                result = await IncomeService.Create(Income);
            }
            
            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/income");
            }
        }

        protected async Task DeleteIncome()
        {
            var result = await IncomeService.Delete(Income.Id);

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/income", true);
            }

        }
    }
}
