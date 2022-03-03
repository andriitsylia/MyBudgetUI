using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System;
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

        public async Task<IncomeModel> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<IncomeModel>($"api/income/{id}");
        }

        public async Task<IEnumerable<IncomeModel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<IncomeModel>>("api/income");
        }

        public async Task<HttpResponseMessage> Update(IncomeModel income)
        {
            return await _httpClient.PutAsJsonAsync<IncomeModel>("api/income", income);
        }

        public async Task<HttpResponseMessage> Create(IncomeModel income)
        {
            return await _httpClient.PostAsJsonAsync<IncomeModel>("api/income", income);
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await _httpClient.DeleteAsync($"api/income/{id}");
        }

        public async Task<IncomeTotalOnDateModel> GetOnDate(DateTime date)
        {
            var s = $"api/income/date={date:yyyy-MM-dd}";
            var result = await _httpClient.GetAsync(s);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<IncomeTotalOnDateModel>();
            }

            return new IncomeTotalOnDateModel()
            {
                Date = date,
                Total = 0,
                Incomes = new List<IncomeModel>()
            };
        }

        public async Task<IncomeTotalOnDateIntervalModel> GetOnDateInterval(DateTime beginDate, DateTime endDate)
        {
            var s = $"api/income/begindate={beginDate:yyyy-MM-dd}&enddate={endDate:yyyy-MM-dd}";
            var result = await _httpClient.GetAsync(s);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<IncomeTotalOnDateIntervalModel>();
            }

            return new IncomeTotalOnDateIntervalModel()
            {
                BeginDate = beginDate,
                EndDate = endDate,
                Total = 0,
                Incomes = new List<IncomeModel>()
            };

        }
    }
}
