using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class ShipmentRateVm
    {
        public int ShipmentRateId { get; set; }

        public string ShipmentRateClass { get; set; } = null!;

        public string ShipmentRateDescription { get; set; } = null!;
    }
}
