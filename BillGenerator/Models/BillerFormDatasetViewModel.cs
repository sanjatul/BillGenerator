namespace BillGenerator.Models
{
    public class BillerFormDatasetViewModel
    {
        public long?Id { get; set; }
        public long BillerId { get; set; }
        public string? BillerName { get; set; } // New property for Biller Name
        public string? DatasetName { get; set; }
        public string? UniqueId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

