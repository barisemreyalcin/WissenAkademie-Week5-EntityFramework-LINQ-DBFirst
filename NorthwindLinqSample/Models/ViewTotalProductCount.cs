using System;
using System.Collections.Generic;

namespace NorthwindLinqSample.Models;

public partial class ViewTotalProductCount
{
    public long? Count { get; set; }

    public int OrderId { get; set; }

    public int? TotalProductCount { get; set; }
}
