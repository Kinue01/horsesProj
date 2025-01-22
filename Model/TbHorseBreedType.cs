﻿using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbHorseBreedType
{
    public short TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<TbHorseBreed> TbHorseBreeds { get; set; } = new List<TbHorseBreed>();
}
