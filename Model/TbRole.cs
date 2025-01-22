﻿using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbRole
{
    public short RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
