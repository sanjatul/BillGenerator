using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class BillerFormFieldType
{
    public long Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<BillerFormDatasetField> BillerFormDatasetFields { get; set; } = new List<BillerFormDatasetField>();
}
