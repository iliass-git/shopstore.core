using ShopStore.DbContext.Entities;
using ShopStore.Models;
namespace ShopStore.Mappers.Interfaces;
public interface ICustomerMapper {
    CustomerEntity MapToCustomerEntity(Customer customer);
    Customer MapToCustomer(CustomerEntity customerEntity);
    IList<Customer> MapToCustomers(IList<CustomerEntity> customerEntities);
    IList<CustomerEntity> MapToCustomerEntities(IList<Customer> customers);
}