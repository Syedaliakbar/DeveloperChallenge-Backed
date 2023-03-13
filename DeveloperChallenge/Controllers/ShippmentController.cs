using DeveloperChallenge.BLL.Services;
using DeveloperChallenge.BLLContacts.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System.Net;

namespace DeveloperChallenge.Controllers
{
    [ApiController]
    [Route("Shippment")]
    public class ShippmentController : ControllerBase
    {
        private IShipperService shipperService;
        public ShippmentController(IShipperService _shipperService)
        {
            shipperService = _shipperService;
        }
        [HttpGet("List")]
        public ResponseModel Index()
        {
            var response = new ResponseModel();
            try
            {
                var result = shipperService.GetShippers();
                if (result != null)
                {
                    if (result != null)
                    {
                        response.Data = result;
                        response.StatusCode = (int)HttpStatusCode.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                response.Data = new object();

            }
            return response;
        }
        [HttpGet("GetById/{id}")]
        public ResponseModel Get(int id)
        {
            var response = new ResponseModel();
            try
            {
                var result = shipperService.GetShippmentById(id);
                if (result != null)
                {
                    if (result != null)
                    {
                        response.Data = result;
                        response.StatusCode = (int)HttpStatusCode.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                response.Data = new object();

            }
            return response;
        }
    }
}
