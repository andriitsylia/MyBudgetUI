using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public interface IExpenseTypeService
    {
        Task<IEnumerable<ExpenseTypeModel>> GetExpenseTypes();
        Task<ExpenseTypeModel> GetExpenseTypeById(int id);
        Task<HttpResponseMessage> UpdateExpenseType(ExpenseTypeModel expenseType);
    }
}
