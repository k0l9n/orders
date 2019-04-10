using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDbContext.Entities
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
            OrdersToArticles = new HashSet<OrdersToArticles>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OxId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        [Required]
        [ForeignKey("OrderState")]
        public int StateId { get; set; }
        public string InvoiceNumber { get; set; }

        public virtual Address Address { get; set; }
        public virtual OrderState OrderState { get; set; }

        public virtual ICollection<OrdersToArticles> OrdersToArticles { get; set; }
    }
}
