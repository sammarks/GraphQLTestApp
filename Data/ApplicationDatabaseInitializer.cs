using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLTestApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLTestApp.Data
{
  public class ApplicationDatabaseInitializer
  {
    public async Task SeedAsync(IApplicationBuilder app)
    {
      using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await applicationDbContext.Database.EnsureDeletedAsync();
        await applicationDbContext.Database.MigrateAsync();
        await applicationDbContext.Database.EnsureCreatedAsync();

        var items = new List<Item>
        {
          new Item {Barcode = "!23", Title = "Headphone", SellingPrice = 50},
          new Item {Barcode = "456", Title = "Keyboard", SellingPrice = 40},
          new Item {Barcode = "789", Title = "Monitor", SellingPrice = 100}
        };
        
        var orders = new List<Order>
        {
          new Order { Tag = "ORD-123", CreatedAt=DateTime.Today, Customer = new Customer { Name= "Jon Doe", BillingAddress="123 Main street"} },
          new Order { Tag = "ORD-456", CreatedAt=DateTime.Today.AddDays(-1), Customer = new Customer { Name= "Jane Doe", BillingAddress="456 Main street"}}
        };

        await applicationDbContext.Items.AddRangeAsync(items);
        await applicationDbContext.Orders.AddRangeAsync(orders);
        await applicationDbContext.SaveChangesAsync();
      }
    }
  }
}