
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionDetailController : Controller
    {
        private readonly ITransactionDetailRepository _transactionDetailRepository;
        private readonly IGenericRepository _genericRepository;

        public TransactionDetailController(ITransactionDetailRepository transactionDetailRepository,IGenericRepository genericRepository) 
        {         
            _transactionDetailRepository = transactionDetailRepository;
            _genericRepository = genericRepository;
        }

        public async Task<IActionResult> TransactionDetails()
        {
            return View(await _transactionDetailRepository.TransactionDetailGetAll());
        }


    }
}
