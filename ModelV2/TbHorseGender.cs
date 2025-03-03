﻿using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbHorseGender
{
    public short GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<TbHorse> TbHorses { get; set; } = new List<TbHorse>();
}
