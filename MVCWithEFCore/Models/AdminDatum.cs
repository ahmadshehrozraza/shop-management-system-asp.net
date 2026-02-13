using System;
using System.Collections.Generic;

namespace MVCWithEFCore.Models;

public partial class AdminDatum
{
    public int Id { get; set; }

    public string AName { get; set; } = null!;

    public string AUsername { get; set; } = null!;

    public string AEmail { get; set; } = null!;

    public string APassword { get; set; } = null!;

    public byte[]? AImage { get; set; }
}
