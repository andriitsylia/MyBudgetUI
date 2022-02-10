using MyBudgetUI.Interfaces;
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

        public async Task<IncomeTypeModel> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<IncomeTypeModel>($"api/incometype/{id}");
        }

        public async Task<IEnumerable<IncomeTypeModel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<IncomeTypeModel>>("api/incometype");
        }

        public async Task<HttpResponseMessage> Update(IncomeTypeModel incomeType)
        {
            return await _httpClient.PutAsJsonAsync<IncomeTypeModel>("api/incometype", incomeType);
        }

        public async Task<HttpResponseMessage> Create(IncomeTypeModel incomeType)
        {
            return await _httpClient.PostAsJsonAsync<IncomeTypeModel>("api/incometype", incomeType);
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await _httpClient.DeleteAsync($"api/incometype/{id}");
        }
    }
}
