using System;
using System.Collections.Generic;

namespace horsesProj.ModelV2;

public partial class TbOffence
{
    public int OffenceId { get; set; }

    public string OffenceName { get; set; } = null!;

    public string? OffenceDescription { get; set; }
}
