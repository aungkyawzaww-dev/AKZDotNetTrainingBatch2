using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.Database.App2DbContextModels;

public partial class TblPhoneShop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Quantity { get; set; } = null!;
}
