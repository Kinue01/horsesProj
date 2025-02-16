using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbRideCompetitor
{
    public int CompetitorId { get; set; }

    public int RideId { get; set; }

    public string JockeyColor { get; set; } = null!;

    public int? HorseRunFail { get; set; }

    public decimal? RideResult { get; set; }

    public virtual TbCompetitor Competitor { get; set; } = null!;

    public virtual TbRide Ride { get; set; } = null!;
}
