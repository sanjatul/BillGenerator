using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class BillerConfiguration
{
    public long Id { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? BillerId { get; set; }

    public string? Purpose { get; set; }

    public string? Configuration { get; set; }
}
