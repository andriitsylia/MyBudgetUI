using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly HttpClient _httpClient;

        public IncomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IncomeModel> GetIncomeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<IncomeModel>($"api/income/{id}");
        }

        public async Task<IEnumerable<IncomeModel>> GetIncomes()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<IncomeModel>>("api/income");
        }
    }
}
