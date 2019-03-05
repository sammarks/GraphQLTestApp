using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestApp
{
  public class DataStore : IDataStore
  {
    private ApplicationDbContext _applicationDbContext;

    public DataStore(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }

    public Item GetItemByBarcode(string barcode)
    {
      return _applicationDbContext.Items.First(i => i.Barcode.Equals(barcode));
    }

    public IEnumerable<Item> GetItems()
    {
      return _applicationDbContext.Items;
    }

    public async Task<Item> AddItem(Item item)
    {
      var addedItem = await _applicationDbContext.Items.AddAsync(item);
      await _applicationDbContext.SaveChangesAsync();
      return addedItem.Entity;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
      return await _applicationDbContext.Items.AsNoTracking().ToListAsync();
    }
    
    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
      return await _applicationDbContext.Orders.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
      return await _applicationDbContext.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int customerId)
    {
      return await _applicationDbContext.Customers.FindAsync(customerId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
    {
      return await _applicationDbContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
    }

    public async Task<Order> AddOrderAsync(Order order)
    {
      var addedOrder = await _applicationDbContext.Orders.AddAsync(order);
      await _applicationDbContext.SaveChangesAsync();
      return addedOrder.Entity;
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
      var addedCustomer = await _applicationDbContext.Customers.AddAsync(customer);
      await _applicationDbContext.SaveChangesAsync();
      return addedCustomer.Entity;
    }

    public async Task<Item> GetItemByIdAsync(int itemId)
    {
      return await _applicationDbContext.Items.FindAsync(itemId);
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
      return await _applicationDbContext.Orders.FindAsync(orderId);
    }

    public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
    {
      var addedOrderItem = await _applicationDbContext.OrderItems.AddAsync(orderItem);
      await _applicationDbContext.SaveChangesAsync();
      return addedOrderItem.Entity;
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
    {
      return await _applicationDbContext.OrderItems.AsNoTracking().ToListAsync();
    }

    public async Task<Dictionary<int, Customer>> GetCustomersByIdAsync(IEnumerable<int> customerIds,
      CancellationToken token)
    {
      return await _applicationDbContext.Customers.Where(i => customerIds.Contains(i.CustomerId))
        .ToDictionaryAsync(x => x.CustomerId, token);
    }

    public async Task<ILookup<int, Order>> GetOrdersByCustomerIdAsync(IEnumerable<int> customerIds)
    {
      var orders = await _applicationDbContext.Orders.Where(i => customerIds.Contains(i.CustomerId)).ToListAsync();
      return orders.ToLookup(i => i.CustomerId);
    }
  }
}