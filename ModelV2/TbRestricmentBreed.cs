using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbRestricmentBreed
{
    public int RestricmentId { get; set; }

    public short BreedId { get; set; }

    public virtual TbHorseBreed Breed { get; set; } = null!;

    public virtual TbRestricment Restricment { get; set; } = null!;
}
