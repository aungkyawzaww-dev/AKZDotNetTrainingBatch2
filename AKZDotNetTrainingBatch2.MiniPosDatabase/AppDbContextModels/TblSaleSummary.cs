using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.MiniPosDatabase.AppDbContextModels;

public partial class TblSaleSummary
{
    public int SaleId { get; set; }

    public string SaleDate { get; set; } = null!;

    public string VoucherNo { get; set; } = null!;

    public string TotalAmount { get; set; } = null!;
}
