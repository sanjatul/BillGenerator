using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class BillerFormDatasetMappingField
{
    public long Id { get; set; }

    public string? MappingFieldName { get; set; }

    public long? BillerId { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? Status { get; set; }
}
