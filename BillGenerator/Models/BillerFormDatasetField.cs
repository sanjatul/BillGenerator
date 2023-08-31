using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class BillerFormDatasetField
{
    public long Id { get; set; }

    public bool? IsMandatory { get; set; }

    public int? MaxLength { get; set; }

    public string? Regex { get; set; }

    public long FieldTypeId { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long DatasetId { get; set; }

    public decimal? MinValue { get; set; }

    public decimal? MaxValue { get; set; }

    public int? FieldOrder { get; set; }

    public string? FieldName { get; set; }

    public string? FriendlyFieldName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<BillerFormDatasetFieldValue> BillerFormDatasetFieldValues { get; set; } = new List<BillerFormDatasetFieldValue>();
    [ValidateNever]
    public virtual BillerFormDataset Dataset { get; set; }
    [ValidateNever]
    public virtual BillerFormFieldType FieldType { get; set; } = null!;
}
