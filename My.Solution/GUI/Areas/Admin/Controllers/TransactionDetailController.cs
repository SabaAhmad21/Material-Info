
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionDetailController : Controller
    {
        private readonly ITransactionDetailRepository _transactionDetailRepository;

        public TransactionDetailController(ITransactionDetailRepository transactionDetailRepository) 
        {         
            _transactionDetailRepository = transactionDetailRepository;
        }

        public async Task<IActionResult> TransactionDetails()
        {
            return View(await _transactionDetailRepository.TransactionDetailGetAll());
        }


    }
}
