using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbJudge
{
    public int JudgeId { get; set; }

    public string JudgeFio { get; set; } = null!;

    public string JudgeTown { get; set; } = null!;

    public string JudgeUserLogin { get; set; } = null!;

    public virtual TbUser JudgeUserLoginNavigation { get; set; } = null!;

    public virtual ICollection<TbCompetition> TbCompetitions { get; set; } = new List<TbCompetition>();
}
