using DeveloperChallenge.DLL.Models;
using Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.BLL.Extensions
{
    public static class CarrierExtension
    {
        public static CarrierVm ConvertDtoToVm(this Carrier dto)
        {
            var vm = new CarrierVm();
            if (dto != null)
            {
                vm.CarrierId = dto.CarrierId;
                vm.CarrierName = dto.CarrierName;
                vm.CarrierMode = dto.CarrierMode;
            }
            return vm;
        }
    }
}
