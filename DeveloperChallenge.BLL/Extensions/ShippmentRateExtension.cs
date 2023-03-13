using DeveloperChallenge.DLL.Models;
using Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.BLL.Extensions
{
    public static class ShippmentRateExtension
    {
        public static ShipmentRateVm ConvertDtoToVm(this ShipmentRate dto)
        {
            var vm = new ShipmentRateVm();
            if (dto != null)
            {
                vm.ShipmentRateId = dto.ShipmentRateId;
                vm.ShipmentRateClass = dto.ShipmentRateClass;
                vm.ShipmentRateDescription = dto.ShipmentRateDescription;
            }
            return vm;
        }
    }
}
