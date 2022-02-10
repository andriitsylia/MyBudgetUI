using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Interfaces
{
    public interface IIncomeService
    {
        Task<IEnumerable<IncomeModel>> GetAll();
        Task<IncomeModel> GetById(int id);
        Task<HttpResponseMessage> Update(IncomeModel income);
        Task<HttpResponseMessage> Create(IncomeModel income);
        Task<HttpResponseMessage> Delete(int id);
    }
}
