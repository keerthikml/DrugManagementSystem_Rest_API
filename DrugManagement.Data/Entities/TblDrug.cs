using System;
using System.Collections.Generic;

namespace DrugManagement.Data.Entities;

public partial class TblDrug
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? SerialNumber { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public virtual TblSupplier? Supplier { get; set; }
}
