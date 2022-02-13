using MyBudgetUI.Interfaces;
using MyBudgetUI.Models;
using System;
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

        public async Task<ExpenseTotalOnDateModel> GetOnDate(DateTime date)
        {
            var result = await _httpClient.GetAsync($"api/expense/date={date.ToShortDateString()}");
            
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ExpenseTotalOnDateModel>();
            }

            return new ExpenseTotalOnDateModel()
            {
                Date = date,
                Total = 0,
                Expenses = new List<ExpenseModel>()
            };
        }

        public async Task<ExpenseTotalOnDateIntervalModel> GetOnDateInterval(DateTime beginDate, DateTime endDate)
        {
            var result = await _httpClient.GetAsync($"api/expense/begindate={beginDate.ToShortDateString()}&enddate={endDate.ToShortDateString()}");

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ExpenseTotalOnDateIntervalModel>();
            }

            return new ExpenseTotalOnDateIntervalModel()
            {
                BeginDate = beginDate,
                EndDate = endDate,
                Total = 0,
                Expenses = new List<ExpenseModel>()
            };
        }
    }
}
