using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseModel>> GetAll();
        Task<ExpenseModel> GetById(int id);
        Task<HttpResponseMessage> Update(ExpenseModel expense);
        Task<HttpResponseMessage> Create(ExpenseModel expense);
        Task<HttpResponseMessage> Delete(int id);
    }
}
