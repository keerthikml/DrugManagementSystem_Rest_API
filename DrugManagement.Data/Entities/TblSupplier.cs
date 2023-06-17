using System;
using System.Collections.Generic;

namespace DrugManagement.Data.Entities;

public partial class TblSupplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<TblDrug> TblDrugs { get; } = new List<TblDrug>();
}
