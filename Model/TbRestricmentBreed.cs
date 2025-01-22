using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbRestricmentBreed
{
    public int TypeId { get; set; }

    public short BreedId { get; set; }

    public virtual TbHorseBreed Breed { get; set; } = null!;

    public virtual TbRestricmentType Type { get; set; } = null!;
}
