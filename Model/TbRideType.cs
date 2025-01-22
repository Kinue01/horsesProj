using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbRideType
{
    public short TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<TbRide> TbRides { get; set; } = new List<TbRide>();
}
