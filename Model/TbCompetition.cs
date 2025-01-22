using System;
using System.Collections.Generic;

namespace horsesProj.Model;

public partial class TbCompetition
{
    public int CompetId { get; set; }

    public DateTime CompetDate { get; set; }

    public string CompetName { get; set; } = null!;
}
