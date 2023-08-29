using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class Biller
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? BillType { get; set; }

    public bool? Status { get; set; }

    public string? Metadata { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillerFormDataset> BillerFormDatasets { get; set; } = new List<BillerFormDataset>();
}
