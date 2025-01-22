using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbJokey
{
    public int JokeyId { get; set; }

    public string JokeyFio { get; set; } = null!;

    public DateTime JokeyBirth { get; set; }

    public int JokeyWeight { get; set; }

    public string JokeyUserLogin { get; set; } = null!;

    public virtual TbUser JokeyUserLoginNavigation { get; set; } = null!;

    public virtual ICollection<TbHorse> TbHorses { get; set; } = new List<TbHorse>();
}
