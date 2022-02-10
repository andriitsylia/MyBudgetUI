using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Interfaces
{
    public interface IExpenseTypeService
    {
        Task<IEnumerable<ExpenseTypeModel>> GetAll();
        Task<ExpenseTypeModel> GetById(int id);
        Task<HttpResponseMessage> Create(ExpenseTypeModel expenseType);
        Task<HttpResponseMessage> Update(ExpenseTypeModel expenseType);
        Task<HttpResponseMessage> Delete(int id);
    }
}
