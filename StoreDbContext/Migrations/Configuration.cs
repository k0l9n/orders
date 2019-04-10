using Enums;
using StoreDbContext.Entities;

namespace StoreDbContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreDbContext context)
        {
            var orderStates = new []
            {
                new OrderState
                {
                    StateId = (int) OrderStates.Processed,
                    Name = "Processed"
                },
                new OrderState
                {
                    StateId = (int) OrderStates.Unprocessed,
                    Name = "Unprocessed"
                },
                new OrderState
                {
                    StateId = (int) OrderStates.Cancelled,
                    Name = "Cancelled"
                }
            };
            context.OrderStates.AddRange(orderStates);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
