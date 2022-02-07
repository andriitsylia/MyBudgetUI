using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public class IncomeTypeService : IIncomeTypeService
    {
        private readonly HttpClient _httpClient;

        public IncomeTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IncomeTypeModel> GetIncomeTypeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<IncomeTypeModel>($"api/incometype/{id}");
        }

        public async Task<IEnumerable<IncomeTypeModel>> GetIncomeTypes()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<IncomeTypeModel>>("api/incometype");
        }
    }
}
