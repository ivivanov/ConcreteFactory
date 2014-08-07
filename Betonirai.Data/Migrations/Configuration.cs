namespace Betonirai.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Betonirai.Data.OrdersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Betonirai.Data.OrdersDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Orders.AddOrUpdate(
            //    p => p.Phone,
            //    new Order()
            //    {
            //        Comment = "Tuka elate na vraca",
            //        Address = "Karnasko shose 1, Vraca, Bulgaria",
            //        DeliveryDate = new DateTime(2014, 11, 1),
            //        DeliveryTime = new DateTime(0001, 01, 01, 12, 51, 0),
            //        Email = "sata@asd.com",
            //        Item = "Beton",
            //        Measure = Enums.Measure.Kilogram,
            //        Phone = "+35423423552",
            //        Quantity = 1,
            //    }
            //    );
        }
    }
}