using System;
using System.Collections.Generic;

namespace DeveloperChallenge.DLL.Models;

public partial class Shipper
{
    public int ShipperId { get; set; }

    public string ShipperName { get; set; } = null!;

    public virtual ICollection<Shipment> Shipments { get; } = new List<Shipment>();
}
