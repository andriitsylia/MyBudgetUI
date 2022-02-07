using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseModel>> GetExpenses();
        Task<ExpenseModel> GetExpenseById(int id);
    }
}
