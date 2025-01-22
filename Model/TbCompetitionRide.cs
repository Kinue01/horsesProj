using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbCompetitionRide
{
    public int CompetId { get; set; }

    public int RideId { get; set; }

    public virtual TbCompetition Compet { get; set; } = null!;

    public virtual TbRide Ride { get; set; } = null!;
}
