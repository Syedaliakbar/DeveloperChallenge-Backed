using DeveloperChallenge.BLLContacts.Services;
using DeveloperChallenge.DLL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using Shared.ViewModel;
using System.Net;

namespace DeveloperChallenge.Controllers
{
    [ApiController]
    [Route("Quotable")]
    public class QuotableController : ControllerBase
    {
        private IQuotableService quotableService;
        public QuotableController(IQuotableService _quotableService)
        {
            quotableService = _quotableService;
        }
        [HttpGet("Random")]
        public ResponseModel Index()
        {
            var response = new ResponseModel();
            try
            {
                var result = quotableService.GetRendom();
                if(result!= null)
                {
                    if(result != null)
                    {
                        response.Data = result;
                        response.StatusCode = (int)result.StatusCode;
                    }
                }
            }
            catch(Exception ex) {
                response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                response.Data = new object();

            }
            return response;
        }
        [HttpGet("Quotes/{authorName}")]
        public ResponseModel Quotes(string authorName)
        {
            var response = new ResponseModel();
            try
            {
                var result = quotableService.GetQuotableList(authorName);
                if(result!= null)
                {
                    if(result != null)
                    {
                        response.Data = result;
                        response.StatusCode = (int)result.StatusCode;
                    }
                }
            }
            catch(Exception ex) {
                response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                response.Data = new object();

            }
            return response;
        }
    }
}
