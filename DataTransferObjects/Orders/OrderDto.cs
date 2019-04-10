using System;

namespace DataTransferObjects.Orders
{
    public class OrderDto
    {
        public OrderDto()
        {
            ArticleIds = new int[0];
        }

        public int Id { get; set; }
        public int OxId { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressId { get; set; }
        public int StateId { get; set; }
        public string InvoiceNumber { get; set; }
        public int[] ArticleIds { get; set; }
    }
}
