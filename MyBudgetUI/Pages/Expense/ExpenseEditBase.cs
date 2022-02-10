using Microsoft.AspNetCore.Components;
using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MyBudgetUI.Interfaces;
using System;
using System.Net.Http;

namespace MyBudgetUI.Pages.Expense
{
    public class ExpenseEditBase : ComponentBase
    {
        public ExpenseModel Expense { get; set; } = new ExpenseModel() { ExpenseType = new ExpenseTypeModel() };

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        public IEnumerable<ExpenseTypeModel> ExpenseTypes { get; set; } = new List<ExpenseTypeModel>();

        [Inject]
        public IExpenseTypeService ExpenseTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public string PageHeader { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int ExpenseId);
            if (ExpenseId > 0)
            {
                PageHeader = "Edit expense";
                Expense = await ExpenseService.GetById(ExpenseId);
            }
            else
            {
                PageHeader = "Create expense";
                Expense = new ExpenseModel() { Date = DateTime.Today, ExpenseType = new ExpenseTypeModel() };
            }
            ExpenseTypes = (await ExpenseTypeService.GetAll()).OrderBy(o => o.Name);
        }

        protected async Task SaveExpense()
        {
            HttpResponseMessage result;

            if (Expense.Id > 0)
            {
                result = await ExpenseService.Update(Expense);
            }
            else
            {
                result = await ExpenseService.Create(Expense);
            }

            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expense");
            }
        }

        protected async Task DeleteExpense()
        {
            var result = await ExpenseService.Delete(Expense.Id);
            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/expense", true);
            }
        }
    }
}
