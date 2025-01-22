using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbUser
{
    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public short UserRoleId { get; set; }

    public virtual ICollection<TbJokey> TbJokeys { get; set; } = new List<TbJokey>();

    public virtual ICollection<TbJudge> TbJudges { get; set; } = new List<TbJudge>();

    public virtual TbRole UserRole { get; set; } = null!;
}
