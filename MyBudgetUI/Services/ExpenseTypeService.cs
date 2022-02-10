using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly HttpClient _httpClient;

        public ExpenseTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExpenseTypeModel> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ExpenseTypeModel>($"api/expensetype/{id}");
        }

        public async Task<IEnumerable<ExpenseTypeModel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExpenseTypeModel>>("api/expensetype");
        }

        public async Task<HttpResponseMessage> Update(ExpenseTypeModel expenseType)
        {
            return await _httpClient.PutAsJsonAsync<ExpenseTypeModel>("api/expensetype", expenseType);
        }

        public async Task<HttpResponseMessage> Create(ExpenseTypeModel expenseType)
        {
            return await _httpClient.PostAsJsonAsync<ExpenseTypeModel>("api/expensetype", expenseType);
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await _httpClient.DeleteAsync($"api/expensetype/{id}");
        }
    }
}
