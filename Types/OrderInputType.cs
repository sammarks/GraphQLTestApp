using GraphQL.Types;

namespace GraphQLTestApp.Types
{
  public class OrderInputType : InputObjectGraphType
  {
    public OrderInputType()
    {
      Name = "OrderInput";
      Field<NonNullGraphType<StringGraphType>>("tag");
      Field<NonNullGraphType<StringGraphType>>("createdAt");
      Field<NonNullGraphType<IntGraphType>>("customerId");
    }
  }
}