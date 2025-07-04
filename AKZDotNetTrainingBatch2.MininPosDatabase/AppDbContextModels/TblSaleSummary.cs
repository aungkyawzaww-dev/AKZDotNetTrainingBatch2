using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;

public partial class TblSaleSummary
{
    public int SaleId { get; set; }

    public DateTime SaleDate { get; set; }

    public string VoucherNo { get; set; } = null!;

    public int TotalAmount { get; set; }

    public bool DeleteFlag { get; set; }
}
