using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Interfaces
{
    public interface IIncomeTypeService
    {
        Task<IEnumerable<IncomeTypeModel>> GetAll();
        Task<IncomeTypeModel> GetById(int id);
        Task<HttpResponseMessage> Update(IncomeTypeModel incomeType);
        Task<HttpResponseMessage> Create(IncomeTypeModel incomeType);
        Task<HttpResponseMessage> Delete(int id);
    }
}
