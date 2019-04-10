using StoreDbContext.Entities;
using StoreDbContext.Migrations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StoreDbContext
{
    public class StoreDbContext : DbContext, IUnitOfWork
    {
        public StoreDbContext() : base("StoreDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderState> OrderStates { get; set; }
        public virtual DbSet<OrdersToArticles> OrdersToArticles { get; set; }

        void IUnitOfWork.SaveChanges()
        {
            SaveChanges();
        }
        public void Initialize()
        {
            var configuration = new Configuration();

            var migrator = new DbMigrator(configuration);

            migrator.Update();
        }
    }
}
