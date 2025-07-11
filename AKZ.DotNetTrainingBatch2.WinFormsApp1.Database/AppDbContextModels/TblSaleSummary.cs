using System;
using System.Collections.Generic;

namespace AKZ.DotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

public partial class TblSaleSummary
{
    public int SaleId { get; set; }

    public DateTime SaleDate { get; set; }

    public string VoucherNo { get; set; } = null!;

    public int TotalAmount { get; set; }

    public bool DeleteFlag { get; set; }
}
