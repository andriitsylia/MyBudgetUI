using MyBudgetUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBudgetUI.Services
{
    public interface IIncomeTypeService
    {
        Task<IEnumerable<IncomeTypeModel>> GetIncomeTypes();
        Task<IncomeTypeModel> GetIncomeTypeById(int id);
    }
}
