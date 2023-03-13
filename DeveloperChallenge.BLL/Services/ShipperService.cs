using DeveloperChallenge.BLL.Extensions;
using DeveloperChallenge.BLLContacts.Services;
using DeveloperChallenge.DLL.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using Shared.Model;
using Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.BLL.Services
{
    public class ShipperService:IShipperService
    {
        public readonly UnitOfWork _unitOfWork;
        public ShipperService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<ShipperVm> GetShippers()
        {
            var shippersList = new List<ShipperVm>();
            try
            {
                var response = _unitOfWork.ShipperRepository.Get();
                if (!response.IsNullOrEmpty())
                {
                    foreach(var item in response)
                    {
                        shippersList.Add(item.ConvertDtoToVm());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return shippersList;
        }
        public List<ShipmentVm> GetShippmentById(int id)
        {
            var shippersList = new List<ShipmentVm>();
            try
            {
                var response = _unitOfWork.GetShippment(id);
                if (!response.IsNullOrEmpty())
                {
                    foreach(var item in response)
                    {
                        shippersList.Add(item.ConvertDtoToVm());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return shippersList;
        }
        
    }
}
