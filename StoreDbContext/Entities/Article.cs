using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDbContext.Entities
{
    [Table("Articles")]
    public class Article
    {
        public Article()
        {
            OrdersToArticles = new HashSet<OrdersToArticles>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Artnum { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }

        public virtual ICollection<OrdersToArticles> OrdersToArticles { get; set; }
    }
}
