using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.Database.App2DbContextModels;

public partial class TblSale
{
    public int No { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }

    public string Discount { get; set; } = null!;
}
