using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.MiniPosDatabase.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
