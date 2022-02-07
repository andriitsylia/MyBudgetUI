using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public interface IExpenseTypeService
    {
        Task<IEnumerable<ExpenseTypeModel>> GetExpenseTypes();
        Task<ExpenseTypeModel> GetExpenseTypeById(int id);
    }
}
