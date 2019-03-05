using GraphQL.Types;
using GraphQLTestApp.Models;

namespace GraphQLTestApp.Types
{
  public class OrderItemType : ObjectGraphType<OrderItem>
  {
    public OrderItemType(IDataStore dataStore)
    {
      Field(i => i.ItemId);
      Field<GraphQLTestApp.ItemType, Item>().Name("Item")
        .ResolveAsync(ctx => dataStore.GetItemByIdAsync(ctx.Source.ItemId));
      Field(i => i.Quantity);
      Field(i => i.OrderId);
      Field<OrderType, Order>().Name("Order")
        .ResolveAsync(ctx => dataStore.GetOrderByIdAsync(ctx.Source.OrderId));
    }
  }
}