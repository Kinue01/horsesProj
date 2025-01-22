using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbRide
{
    public int RideId { get; set; }

    public string RideName { get; set; } = null!;

    public short RideTypeId { get; set; }

    public int RideDistance { get; set; }

    public int RidePayment { get; set; }

    public TimeOnly RideTime { get; set; }

    public int RideNum { get; set; }

    public int RideRestricmentType { get; set; }

    public virtual TbRestricmentType RideRestricmentTypeNavigation { get; set; } = null!;

    public virtual TbRideType RideType { get; set; } = null!;
}
