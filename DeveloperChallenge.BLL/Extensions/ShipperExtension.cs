using DeveloperChallenge.DLL.Models;
using Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.BLL.Extensions
{
    public static class ShipperExtension
    {
        public static ShipperVm ConvertDtoToVm(this Shipper dto)
        {
            var vm = new ShipperVm();
            if(dto != null)
            {
                vm.ShipperId= dto.ShipperId;
                vm.ShipperName= dto.ShipperName;
            }
            return vm;
        }
    }
}
