using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient _httpClient;

        public ExpenseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExpenseModel> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ExpenseModel>($"api/expense/{id}");
        }

        public async Task<IEnumerable<ExpenseModel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExpenseModel>>("api/expense");
        }

        public async Task<HttpResponseMessage> Update(ExpenseModel expense)
        {
            return await _httpClient.PutAsJsonAsync<ExpenseModel>("api/expense", expense);
        }

        public async Task<HttpResponseMessage> Create(ExpenseModel expense)
        {
            return await _httpClient.PostAsJsonAsync<ExpenseModel>("api/expense", expense);
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await _httpClient.DeleteAsync($"api/expense/{id}");
        }
    }
}
