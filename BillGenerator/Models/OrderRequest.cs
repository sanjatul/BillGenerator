namespace BillGenerator.Models
{
    public class OrderRequest
    {
        public string DatasetName { get; set; }
        public string UniqueId { get; set; }
        public long BillerId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderItem> Order { get; set; }
    }
}
