using System;
using System.Collections.Generic;

namespace BillGenerator.Models;

public partial class BillerAssignment
{
    public long Id { get; set; }

    public long? BillerId { get; set; }

    public long? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
