using Newtonsoft.Json.Linq;

namespace GraphQLTestApp
{
  public class GraphQLRequest
  {
    public string Query { get; set; }
    public JObject Variables { get; set; }
  }
}