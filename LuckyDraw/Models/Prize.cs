using System;
using System.Collections.Generic;

namespace LuckyDraw.Models;

public partial class Prize
{
    public int ID { get; set; }

    public string? PrizeName { get; set; }

    public int? LuckyNumber { get; set; }

    public int? YearValue { get; set; }
}
