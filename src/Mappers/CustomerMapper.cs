using ShopStore.Models;
using ShopStore.DbContext.Entities;
using ShopStore.Mappers.Interfaces;
namespace ShopStore.Mappers;

public class CustomerMapper: ICustomerMapper {

    public CustomerEntity MapToCustomerEntity(Customer customer){
        return new CustomerEntity{
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            Mobile = customer.Mobile,
            FixedLine = customer.FixedLine,
            UserInfo = customer.UserInfo
        };
    }
    public Customer MapToCustomer(CustomerEntity customerEntity){
        return new Customer{
            Id = customerEntity.Id,
            FirstName = customerEntity.FirstName,
            LastName = customerEntity.LastName,
            Address = customerEntity.Address,
            Mobile = customerEntity.Mobile,
            FixedLine = customerEntity.FixedLine,
            UserInfo = customerEntity.UserInfo
        };
    }

    public IList<Customer> MapToCustomers(IList<CustomerEntity> customerEntities){
        IList<Customer> customers = new List<Customer>();
        foreach(CustomerEntity customerEntity in customerEntities){
            customers.Add(MapToCustomer(customerEntity));
        }
        return customers;
    }

    public IList<CustomerEntity> MapToCustomerEntities(IList<Customer> customers){
        IList<CustomerEntity> customerEntities = new List<CustomerEntity>();
        foreach(Customer customer in customers){
            customerEntities.Add(MapToCustomerEntity(customer));
        }
        return customerEntities;
    }

}