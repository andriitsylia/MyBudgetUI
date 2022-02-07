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

        public async Task<ExpenseTypeModel> GetExpenseTypeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ExpenseTypeModel>($"api/expensetype/{id}");
        }

        public async Task<IEnumerable<ExpenseTypeModel>> GetExpenseTypes()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExpenseTypeModel>>("api/expensetype");
        }
    }
}
