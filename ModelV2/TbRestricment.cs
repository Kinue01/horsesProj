using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbRestricment
{
    public int RestricmentId { get; set; }

    public string RestricmentGender { get; set; } = null!;

    public int RestricmentAgeLower { get; set; }

    public int RestricmentAgeUpper { get; set; }

    public string RestricmentHorseBirthplace { get; set; } = null!;

    public virtual ICollection<TbRide> TbRides { get; set; } = new List<TbRide>();
}
