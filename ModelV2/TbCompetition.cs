﻿using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbCompetition
{
    public int CompetId { get; set; }

    public DateTime CompetDate { get; set; }

    public string CompetName { get; set; } = null!;

    public int CompetJudgeId { get; set; }

    public virtual TbJudge CompetJudge { get; set; } = null!;

    public virtual ICollection<TbRide> TbRides { get; set; } = new List<TbRide>();
}
