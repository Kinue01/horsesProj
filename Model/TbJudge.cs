using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbJudge
{
    public int JudgeId { get; set; }

    public string UserFio { get; set; } = null!;

    public string UserTown { get; set; } = null!;

    public string JudgeUserLogin { get; set; } = null!;

    public virtual TbUser JudgeUserLoginNavigation { get; set; } = null!;
}
