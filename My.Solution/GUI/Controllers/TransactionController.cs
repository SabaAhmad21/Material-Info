using Infrastructure.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly ISupplierRepository _supplierRepository;

        public TransactionController(ITransactionRepository transactionRepository,
            ISupplierRepository supplierRepository,IGenericRepository genericRepository) 
        { 
            _transactionRepository = transactionRepository;
            _genericRepository= genericRepository;
            _supplierRepository = supplierRepository;
        
        }
        public async Task<IActionResult> Transactions()
        {
            return View(await _transactionRepository.TransactionGetAll());
        }

        public async Task<IActionResult> TransactionCreate()
        {
            return View (new TransactionCreateVM()
            {
                Suppliers = await _supplierRepository.SupplierGetAll(),
                TransactionDate = DateTime.Now

            });
        }
        [HttpPost]
        public async Task<IActionResult> TransactionCreate(TransactionCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var transactionVM = await _transactionRepository.TransactionCreate(model);
                return RedirectToAction("TransactionDetialCreate", "TransDetail" , transactionVM);
                //if (transactionVM)
                //{
                //    ModelState.AddModelError("", "Transaction successfully Done");
                //}

            }
            return View(new TransactionCreateVM
            {
                Suppliers = await _supplierRepository.SupplierGetAll()
            });
        }

        [HttpGet]
       public async Task<IActionResult> TransactionUpdate(int Id)
        {
            return View(await _transactionRepository.TransactionGetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> TransactionUpdate(TransactionUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var transactionVM = await _transactionRepository.TransactionUpdate(model);
                if (transactionVM)
                {
                    ModelState.AddModelError("", "Transaction Updated successfully");
                }
                else
                {
                    ModelState.AddModelError("", "Error has been occured!");
                }
            }
            return View(await _transactionRepository.TransactionGetById(model.TransactionId));
            
        }
        public async Task<IActionResult> TransactionDelete(int Id)
        {
            var result = await _transactionRepository.TransactionDelete(Id);
            return RedirectToAction("Transactions", new {Controller = this});
        }
      
    }
}
