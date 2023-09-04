using BillGenerator.Abstractions.Requests;

namespace BillGenerator.Abstractions
{
    public class UpdateOrder
    {
        public long Id { get; set; }
        public List<OrderField>? Order { get; set; }
    }
}
