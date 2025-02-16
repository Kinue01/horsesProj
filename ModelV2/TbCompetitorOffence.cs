using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbCompetitorOffence
{
    public int OffenceId { get; set; }

    public int CompetitorId { get; set; }

    public virtual TbCompetitor Competitor { get; set; } = null!;

    public virtual TbOffence Offence { get; set; } = null!;
}
