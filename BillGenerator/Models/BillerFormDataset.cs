using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class BillerFormDataset
{
    public long Id { get; set; }

    public string? DatasetName { get; set; }

    public string? UniqueId { get; set; }

    public long BillerId { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
    [ValidateNever]
    public virtual Biller Biller { get; set; } = null!;

    public virtual ICollection<BillerFormDatasetField> BillerFormDatasetFields { get; set; } = new List<BillerFormDatasetField>();
}
