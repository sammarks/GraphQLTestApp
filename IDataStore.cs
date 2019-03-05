using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLTestApp.Models;

namespace GraphQLTestApp
{
  public interface IDataStore
  {
    IEnumerable<Item> GetItems();
    Item GetItemByBarcode(string barcode);
    Task<Item> AddItem(Item item);
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int customerId);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
    Task<Order> AddOrderAsync(Order order);
    Task<Customer> AddCustomerAsync(Customer customer);
    Task<Item> GetItemByIdAsync(int itemId);
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<OrderItem>> GetOrderItemsAsync();
    Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
    Task<Dictionary<int, Customer>> GetCustomersByIdAsync(IEnumerable<int> customerIds, CancellationToken token);
    Task<ILookup<int, Order>> GetOrdersByCustomerIdAsync(IEnumerable<int> customerIds);
  }
}