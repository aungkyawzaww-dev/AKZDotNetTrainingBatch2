using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public bool DeleteFlag { get; set; }
}
