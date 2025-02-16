using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbRide
{
    public int RideId { get; set; }

    public string RideName { get; set; } = null!;

    public short RideTypeId { get; set; }

    public int RideDistance { get; set; }

    public int RidePayment { get; set; }

    public TimeOnly RideTime { get; set; }

    public int RideNum { get; set; }

    public int RideRestricment { get; set; }

    public int RideCompetition { get; set; }

    public virtual TbCompetition RideCompetitionNavigation { get; set; } = null!;

    public virtual TbRestricment RideRestricmentNavigation { get; set; } = null!;

    public virtual TbRideType RideType { get; set; } = null!;

    public virtual ICollection<TbRideCompetitor> TbRideCompetitors { get; set; } = new List<TbRideCompetitor>();
}
