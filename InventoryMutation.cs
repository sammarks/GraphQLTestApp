using GraphQL.Types;
using GraphQLTestApp.Models;
using GraphQLTestApp.Types;

namespace GraphQLTestApp
{
  public class InventoryMutation : ObjectGraphType
  {
    public InventoryMutation(IDataStore dataStore)
    {
      Field<ItemType>("createItem", arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<ItemInputType>> {Name = "item"}
        ),
        resolve: context =>
        {
          var item = context.GetArgument<Item>("item");
          return dataStore.AddItem(item);
        });
      Field<OrderItemType, OrderItem>()
        .Name("addOrderItem")
        .Argument<NonNullGraphType<OrderItemInputType>>("orderitem", "orderitem input")
        .ResolveAsync(ctx =>
        {
          var orderItem = ctx.GetArgument<OrderItem>("orderitem");
          return dataStore.AddOrderItemAsync(orderItem);
        });
    }
  }
}