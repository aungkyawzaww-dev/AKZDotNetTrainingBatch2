using System;
using System.Collections.Generic;

namespace AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;

public partial class TblStaffRegister
{
    public int Staffid { get; set; }

    public string Staffcode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Position { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
