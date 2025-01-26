using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbHorse
{
    public int HorseId { get; set; }

    public string HorseName { get; set; } = null!;

    public DateOnly HorseYear { get; set; }

    public short HorseGenderId { get; set; }

    public short HorseBreedId { get; set; }

    public string HorseTrainerFio { get; set; } = null!;

    public string HorseOwnerFio { get; set; } = null!;

    public decimal? HorseSpeed { get; set; }

    public int HorseRunFail { get; set; }

    public virtual TbHorseBreed HorseBreed { get; set; } = null!;

    public virtual TbHorseGender HorseGender { get; set; } = null!;
}
