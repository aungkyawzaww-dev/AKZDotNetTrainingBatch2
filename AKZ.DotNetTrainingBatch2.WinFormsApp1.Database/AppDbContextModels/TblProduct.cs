using System;
using System.Collections.Generic;

namespace AKZ.DotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public bool DeleteFlag { get; set; }
}
