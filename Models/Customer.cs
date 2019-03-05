using System.Collections.Generic;

namespace GraphQLTestApp.Models
{
  public class Customer
  {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string BillingAddress { get; set; }
    public IEnumerable<Order> Orders { get; set; }
  }
}