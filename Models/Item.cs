using System.Collections.Generic;

namespace GraphQLTestApp.Models
{
  public class Item
  {
    public int Id { get; set; }
    public string Barcode { get; set; }
    public string Title { get; set; }
    public decimal SellingPrice { get; set; }
    
    public IEnumerable<OrderItem> OrderItems { get; set; }
  }
}