using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbRideCompetitor
{
    public int RideId { get; set; }

    public int JokeyId { get; set; }

    public string JokeyColor { get; set; } = null!;

    public short HorseRow { get; set; }

    public virtual TbJokey Jokey { get; set; } = null!;

    public virtual TbRide Ride { get; set; } = null!;
}
