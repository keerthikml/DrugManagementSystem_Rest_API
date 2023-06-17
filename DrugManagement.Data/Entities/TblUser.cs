using System;
using System.Collections.Generic;

namespace DrugManagement.Data.Entities;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public byte[] Password { get; set; } = null!;
}
