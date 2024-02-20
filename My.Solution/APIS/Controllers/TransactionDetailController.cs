using Domain;
using Infrastructure.Implementations;
using Infrastructure.ViewModels;
using Infrastructure.ViewModels.ApisVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDetailController : ControllerBase
    {
        private readonly TransactionDetailRepository _transactionDetailRepository;

        public TransactionDetailController(TransactionDetailRepository transactionDetailRepository)
        {
            _transactionDetailRepository = transactionDetailRepository;

        }

        [HttpGet]
        [Route("TransactionDetailGetAll")]
        public async Task<ResponseModel> TransactionDetailGetAll()
        {
            return ResponseModel.Success(await _transactionDetailRepository.TransactionDetailGetAll(), "Transaction Details");
        }

        [HttpPost]
        [Route("TransactionDetailCreate")]

        public async Task<ResponseModel> TransactionDetailCreate([FromBody]TransactionDetailCreateVM model)
        {
            return ResponseModel.Created(await _transactionDetailRepository.TransactionDetailCreate(model), "Transactiondetails Created!");
        }
        [HttpPut]
        [Route("TransactionDetailUpdate")]

        public async Task<ResponseModel> TransactionDetailUpdate([FromBody] TransactionDetailUpdateVM model)
        {
            return ResponseModel.Success(await _transactionDetailRepository.TransactionDetailUpdate(model), "Details Updated");
        }
        [HttpDelete]
        [Route("TransactionDetailDelete")]
        public async Task<ResponseModel> TransactionDetailDelete(int Id)
        {
            return ResponseModel.Success(await _transactionDetailRepository.TransactionDetailDelete(Id), "Details Deleted");
        }
    }
}
