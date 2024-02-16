using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITransactionDetailRepository 
    {
        Task<TransactionDetailUpdateVM> TransactionDetailGetById(int Id);

        Task<bool> TransactionDetailCreate(TransactionDetailCreateVM model);

        Task<bool> TransactionDetailUpdate(TransactionDetailUpdateVM model);

        Task<IEnumerable<TransactionDetailVM>> TransactionDetailGetAll();

        Task<bool> TransactionDetailDelete(int Id);
    }
}
