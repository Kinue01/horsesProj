using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbRestricmentType
{
    public int TypeId { get; set; }

    public string TypeGender { get; set; } = null!;

    public int TypeAgeLower { get; set; }

    public int TypeAgeUpper { get; set; }

    public string TypeHorseBirthplace { get; set; } = null!;

    public virtual ICollection<TbRide> TbRides { get; set; } = new List<TbRide>();
}
