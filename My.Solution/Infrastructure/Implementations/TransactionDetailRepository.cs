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
    public class TransactionDetailRepository : ITransactionDetailRepository
    {
        private  MaterialInfoDbContext _context;
        private  IGenericRepository _genericRepository;
        private IRawMaterialRepository _rawMaterialRepository;
        private ISupplierRepository _supplierRepository;
        private ITransactionRepository _transactionRepository;

        public TransactionDetailRepository(IGenericRepository genericRepository, MaterialInfoDbContext context, IRawMaterialRepository rawMaterialRepository, ISupplierRepository supplierRepository, ITransactionRepository transactionRepository ) 
            
        {

            _context = context;
            _genericRepository = genericRepository;
            _rawMaterialRepository = rawMaterialRepository;
            _supplierRepository = supplierRepository;
            _transactionRepository = transactionRepository;

        }

        public async Task<bool> TransactionDetailCreate(TransactionDetailCreateVM model)
        {
            return await _genericRepository.Create(new TransactionDetail()
            {
                Quantity = model.Quantity,
                NoOfItems = model.NoOfItems,
                Price = model.Price,
                CreatedDate = DateTime.Now,
                UpdateDate=DateTime.Now,
                //SupplierId = model.SupplierId,
                MaterialId = model.MaterialId,
                TransactionId = model.TransactionId,
            });
        }
        public async Task<TransactionDetailUpdateVM> TransactionDetailGetById(int Id)
        {
            var transactionDetails = await _context.TransactionDetails.Where(p=>p.TransDetailsId == Id).FirstOrDefaultAsync();
            if(transactionDetails != null)
            {
                return new TransactionDetailUpdateVM
                {
                    TransDetailsId = transactionDetails.TransDetailsId,
                    Quantity = transactionDetails.Quantity,
                    UpdateDate = DateTime.Now,
                    NoOfItems = transactionDetails.NoOfItems,
                    Price = transactionDetails.Price,
                    MaterialId = transactionDetails.MaterialId,
                    //SupplierId = transactionDetails.SupplierId,
                    TransactionId= transactionDetails.TransactionId,

                    RawMaterials = await _rawMaterialRepository.MaterialGetAll(),
                    //Suppliers = await _supplierRepository.SupplierGetAll(),
                    Transactions = await _transactionRepository.TransactionGetAll()

                };
            }
            return null;

        }
        public async Task<bool> TransactionDetailUpdate(TransactionDetailUpdateVM model)
        {
            var transactionDetails = await _context.TransactionDetails.Where(p=>p.TransDetailsId == model.TransDetailsId).FirstOrDefaultAsync();
            if(transactionDetails != null)
            {
                transactionDetails.Quantity = model.Quantity;
                transactionDetails.Price = model.Price;
                transactionDetails.NoOfItems = model.NoOfItems;
                transactionDetails.UpdateDate = DateTime.Now;
                //transactionDetails.SupplierId = model.SupplierId;
                transactionDetails.MaterialId = model.MaterialId;
                transactionDetails.TransactionId = model.TransactionId;
                return await _genericRepository.Update(transactionDetails);

            }

            return false;

        }

        public async Task<IEnumerable<TransactionDetailVM>> TransactionDetailGetAll()
        {
            var detailVM = new List<TransactionDetailVM>();
            var TransactionDetails = await _context.TransactionDetails.Include(p => p.Transaction).ToListAsync();
            if(TransactionDetails != null && TransactionDetails.Count() > 0)
            {
                foreach(var item in TransactionDetails)
                {
                    detailVM.Add(new TransactionDetailVM
                    {
                        Quantity = item.Quantity,
                        Price = item.Price,
                        NoOfItems = item.NoOfItems,
                        UpdateDate = DateTime.Now,
                        Transaction=item.Transaction.Name,
                        TransDetailsId = item.TransDetailsId
                    });
                }
                return detailVM;
            }
            return detailVM;
        }

        public async Task<bool> TransactionDetailDelete(int Id)
        {
            var transactionDetail = await _context.TransactionDetails.Where(p=>p.TransDetailsId == Id).FirstOrDefaultAsync();
            if(transactionDetail != null)
            {
                return await _genericRepository.Delete(transactionDetail);
            }
            return false;
        }


    }
}

