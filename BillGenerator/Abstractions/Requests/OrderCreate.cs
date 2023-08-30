using System.Text.Json.Serialization;

namespace BillGenerator.Abstractions.Requests
{
    public class OrderCreate
    {
        public string? DatasetName { get; set; }
        public string UniqueId { get; set; }
        public long BillerId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<OrderField>? Order { get; set; }
    }

    public class OrderField
    {
        public string? FieldName { get; set; }
        public int? MaxLength { get; set; }
        public string? Regex { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public int? FieldOrder { get; set; }
        public string? FriendlyFieldName { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IsMandatory { get; set; }
        public int? IsActive { get; set; }
        public long FieldTypeId { get; set; }
        public long DatasetId { get; set; }
    }

}
