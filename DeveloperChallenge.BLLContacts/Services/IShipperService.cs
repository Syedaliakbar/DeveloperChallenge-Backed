using Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.BLLContacts.Services
{
    public interface IShipperService
    {
        List<ShipperVm> GetShippers();
        List<ShipmentVm> GetShippmentById(int id);
    }
}
