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

        public async Task<ExpenseModel> GetExpenseById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ExpenseModel>($"api/expense/{id}");
        }

        public async Task<IEnumerable<ExpenseModel>> GetExpenses()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExpenseModel>>("api/expense");
        }
    }
}
