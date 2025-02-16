using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbUser
{
    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public short UserRoleId { get; set; }

    public virtual ICollection<TbJockey> TbJockeys { get; set; } = new List<TbJockey>();

    public virtual ICollection<TbJudge> TbJudges { get; set; } = new List<TbJudge>();

    public virtual TbRole UserRole { get; set; } = null!;
}
