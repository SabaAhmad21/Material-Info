using Domain;
using Infrastructure.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private MaterialInfoDbContext _context;
        private IGenericRepository _genericRepository;
        private ISupplierRepository _supplierRepository;

        public TransactionRepository(MaterialInfoDbContext context, IGenericRepository genericRepository, ISupplierRepository supplierRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
            _supplierRepository = supplierRepository;

        }

        //public async Task<bool> TransactionCreate(TransactionCreateVM model)
        public async Task<Transaction> TransactionCreate(TransactionCreateVM model)
        {
            var result =  await _genericRepository.Create(new Transaction()
            {
                Name = model.Name,
                TotalPrice = model.TotalPrice,
                CreatedDate = DateTime.Now,
                TransactionDate = DateTime.Now,
                SupplierId = model.SupplierId,
            });
            var transactionCreated = await _context.Transactions.OrderByDescending(p => p.CreatedDate).Take(1).FirstOrDefaultAsync();
            return transactionCreated;
        }

        public async Task<bool> TransactionUpdate(TransactionUpdateVM model)
        {
            var transaction = await _context.Transactions.Where(p => p.TransactionId == model.TransactionId).FirstOrDefaultAsync();
            if (transaction != null)
            {
                transaction.TransactionId = model.TransactionId;
                transaction.TotalPrice = model.TotalPrice;
                transaction.CreatedDate = DateTime.Now;
                transaction.TransactionDate = DateTime.Now;
                transaction.SupplierId = model.SupplierId;

                return await _genericRepository.Update(transaction);

            }
            return true;
        }

        public async Task<TransactionUpdateVM> TransactionGetById(int Id)
        {
            var transaction = await _context.Transactions.Where(p => p.TransactionId == Id).FirstOrDefaultAsync();
            if (transaction != null)
            {
                return new TransactionUpdateVM()

                {

                    TransactionId = transaction.TransactionId,
                    TotalPrice = transaction.TotalPrice,
                    CreatedDate = transaction.CreatedDate,
                    TransactionDate = transaction.TransactionDate,
                    SupplierId = transaction.SupplierId,

                    Suppliers = await _supplierRepository.SupplierGetAll()
                };
            }
            return null;

            }
      

        public async Task<IEnumerable<TransactionVM>> TransactionGetAll()
        {
            var transactionVM = new List<TransactionVM>();
            var Transactions = await _context.Transactions.Include(p =>p.Supplier).ToListAsync();
            if(Transactions != null && Transactions.Count() > 0)
            {
                foreach (var transaction in Transactions)
                {
                    transactionVM.Add(new TransactionVM()
                    {
                        TransactionId = transaction.TransactionId,
                        TotalPrice = transaction.TotalPrice,
                        CreatedDate = transaction.CreatedDate,
                        TransactionDate = transaction.TransactionDate,                        
                        Name = transaction.Name,
                        Supplier=transaction.Supplier.SupplierName

                    });
                }
                return transactionVM;
            }
            return transactionVM;
        }

        public async Task<bool> TransactionDelete(int Id)
        {
            var transaction = await _context.Transactions.Where(p => p.TransactionId == Id).FirstOrDefaultAsync();
            if (transaction != null)
            {
                return await _genericRepository.Delete(transaction);
            }
            return false;


        }
    }


}

