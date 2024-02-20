using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels.ApisVM
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public dynamic Data { get; set; }
        public static ResponseModel Success(dynamic payload, string message)
        {
            return new ResponseModel
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = message,
                Status = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.OK),
                Data = payload
            };
        }
        public static ResponseModel Success(string message)
        {
            return new ResponseModel
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = message,
                Status = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.OK),
            };
        }
        public static ResponseModel Created(dynamic payload, string message)
        {
            return new ResponseModel
            {
                StatusCode = (int)HttpStatusCode.Created,
                Message = message,
                Status = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.Created),
                Data = payload
            };
        }
        public static ResponseModel NotFound(string message)
        {
            return new ResponseModel
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Message = message,
                Status = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.NotFound)
            };
        }
        public static ResponseModel Failure(dynamic payload, string message)
        {
            return new ResponseModel
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Status = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.InternalServerError),
                Message = message,
                Data = payload
            };
        }
        public static ResponseModel Failure(string message)
        {
            return new ResponseModel
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Status = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.InternalServerError),
                Message = message
            };
        }
    }
}
