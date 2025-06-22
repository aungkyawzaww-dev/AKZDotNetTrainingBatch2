using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.MiniPosDatabase.AppDbContextModels;

public partial class TblSaleDetail
{
    public int SaleDetailId { get; set; }

    public string SaleId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public string Price { get; set; } = null!;
}
