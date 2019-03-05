using GraphQL.Types;

namespace GraphQLTestApp.Types
{
  public class CustomerInputType : InputObjectGraphType
  {
    public CustomerInputType()
    {
      Name = "CustomerInput";
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("billingAddress");
    }
  }
}