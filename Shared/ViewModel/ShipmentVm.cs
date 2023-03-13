using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class ShipmentVm
    {
        public int ShipmentId { get; set; }

        public int ShipperId { get; set; }

        public string ShipmentDescription { get; set; } = null!;

        public decimal ShipmentWeight { get; set; }

        public int ShipmentRateId { get; set; }

        public int CarrierId { get; set; }

        public virtual CarrierVm Carrier { get; set; } = null!;

        public virtual ShipmentRateVm ShipmentRate { get; set; } = null!;

        public virtual ShipperVm Shipper { get; set; } = null!;
    }
}
