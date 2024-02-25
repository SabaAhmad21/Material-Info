using Domain;
using Infrastructure.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace GUI.Controllers
{
    public class TransDetailController : Controller
    {
        private MaterialInfoDbContext _context;
        private IGenericRepository _genericRepository;
        private IRawMaterialRepository _rawMaterialRepository;
        private ISupplierRepository _supplierRepository;
        private ITransactionRepository _transactionRepository;

        public TransDetailController(IGenericRepository genericRepository, MaterialInfoDbContext context, IRawMaterialRepository rawMaterialRepository, ISupplierRepository supplierRepository, ITransactionRepository transactionRepository)

        {

            _context = context;
            _genericRepository = genericRepository;
            _rawMaterialRepository = rawMaterialRepository;
            _supplierRepository = supplierRepository;
            _transactionRepository = transactionRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TransactionDetialCreate(Domain.Transaction transaction)
        {
            var modelCreate = new TransactionDetailCreateVM()
            {
                transaction = transaction,
                TransactionId = transaction.TransactionId,
                RawMaterials = _context.RawMaterials.ToList(),
                //  RawMaterials 
            };
            var model = new TransactionDetailsInclude()
            {
                details = modelCreate,
                transaction = transaction
            };
            return View(model);
        }
    }
}
