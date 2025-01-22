using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbHorseBreed
{
    public short BreedId { get; set; }

    public string BreedName { get; set; } = null!;

    public short BreedTypeId { get; set; }

    public virtual TbHorseBreedType BreedType { get; set; } = null!;

    public virtual ICollection<TbHorse> TbHorses { get; set; } = new List<TbHorse>();
}
