using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbHorse
{
    public int HorseId { get; set; }

    public string HorseName { get; set; } = null!;

    public int HorseBirthYear { get; set; }

    public short HorseGenderId { get; set; }

    public short HorseBreedId { get; set; }

    public string HorseTrainerFio { get; set; } = null!;

    public int HorseOwnerId { get; set; }

    public virtual TbHorseBreed HorseBreed { get; set; } = null!;

    public virtual TbHorseGender HorseGender { get; set; } = null!;

    public virtual TbJockey HorseOwner { get; set; } = null!;

    public virtual ICollection<TbCompetitor> TbCompetitors { get; set; } = new List<TbCompetitor>();
}
