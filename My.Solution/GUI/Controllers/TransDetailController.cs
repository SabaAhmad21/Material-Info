using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace GUI.Controllers
{
    public class TransDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TransactionDetialCreate(Domain.Transaction transaction)
        {
            var model = new TransactionDetailCreateVM()
            {
                transaction = transaction,
                 TransactionId = transaction.TransactionId,
                 CreatedDate = transaction.CreatedDate,
                TransactionDate=


            };
            return View();
        }
    }
}
