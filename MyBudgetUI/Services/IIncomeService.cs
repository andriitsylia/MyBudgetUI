using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public interface IIncomeService
    {
        Task<IEnumerable<IncomeModel>> GetIncomes();
        Task<IncomeModel> GetIncomeById(int id);
    }
}
