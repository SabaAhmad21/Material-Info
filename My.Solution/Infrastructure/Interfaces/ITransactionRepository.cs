using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionUpdateVM> TransactionGetById(int Id);
        Task<bool> TransactionCreate(TransactionCreateVM model);
        Task<bool> TransactionUpdate(TransactionUpdateVM model);
        Task<IEnumerable<TransactionVM>> TransactionGetAll();
        Task<bool> TransactionDelete(int Id);
       
    }
}
