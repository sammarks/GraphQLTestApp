using GraphQL.Types;
using GraphQLTestApp.Models;

namespace GraphQLTestApp
{
  public class ItemType : ObjectGraphType<Item>
  {
    public ItemType()
    {
      Field(i => i.Barcode);
      Field(i => i.Title);
      Field(i => i.SellingPrice);
    }
  }
}