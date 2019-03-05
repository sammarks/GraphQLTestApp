using GraphQL.Types;

namespace GraphQLTestApp.Types
{
  public class OrderItemInputType : InputObjectGraphType
  {
    public OrderItemInputType()
    {
      Name = "OrderItemInput";
      Field<NonNullGraphType<IntGraphType>>("quantity");
      Field<NonNullGraphType<IntGraphType>>("itemId");
      Field<NonNullGraphType<IntGraphType>>("orderId");
    }
  }
}