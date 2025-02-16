using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbCompetitor
{
    public int CompetitorId { get; set; }

    public int CompetitorJockeyId { get; set; }

    public int CompetitorHorseId { get; set; }

    public bool CompetitorDisqualification { get; set; }

    public int? CompetitorRow { get; set; }

    public virtual TbHorse CompetitorHorse { get; set; } = null!;

    public virtual TbJockey CompetitorJockey { get; set; } = null!;

    public virtual ICollection<TbRideCompetitor> TbRideCompetitors { get; set; } = new List<TbRideCompetitor>();
}
