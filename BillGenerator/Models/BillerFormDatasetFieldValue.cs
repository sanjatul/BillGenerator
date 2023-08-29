using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class BillerFormDatasetFieldValue
{
    public long Id { get; set; }

    public string? Value { get; set; }

    public bool? IsDefault { get; set; }

    public long DatasetFieldId { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Text { get; set; }

    public virtual BillerFormDatasetField DatasetField { get; set; } = null!;
}
