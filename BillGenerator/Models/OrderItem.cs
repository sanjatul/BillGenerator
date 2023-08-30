namespace BillGenerator.Models
{
    public class OrderItem
    {
        public string FieldName { get; set; }
        public long MaxLength { get; set; }
        public string Regex { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long MinValue { get; set; }
        public long MaxValue { get; set; }
        public long FieldOrder { get; set; }
        public string FriendlyFieldName { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsActive { get; set; }
        public long FieldTypeId { get; set; }
        public long DatasetId { get; set; }
    }
}
