using DeveloperChallenge.DLL.Models;
using Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.BLL.Extensions
{
    public static class ShippmentExtension
    {
        public static ShipmentVm ConvertDtoToVm(this Shipment dto)
        {
            var vm = new ShipmentVm();
            if (dto != null)
            {
                vm.ShipmentId = dto.ShipmentId;
                vm.ShipperId = dto.ShipperId;
                vm.ShipmentDescription = dto.ShipmentDescription;
                vm.ShipmentWeight = dto.ShipmentWeight;
                vm.ShipmentRateId = dto.ShipmentRateId;
                vm.CarrierId = dto.CarrierId;
                vm.ShipmentRateId = dto.ShipmentRateId;
                vm.Carrier = dto.Carrier.ConvertDtoToVm();
                vm.Shipper = dto.Shipper.ConvertDtoToVm();
                vm.ShipmentRate = dto.ShipmentRate.ConvertDtoToVm();
            }
            return vm;
        }
    }
}
