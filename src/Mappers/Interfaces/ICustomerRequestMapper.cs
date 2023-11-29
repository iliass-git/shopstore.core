using ShopStore.DbContext.Entities;
using ShopStore.Models;
namespace ShopStore.Mappers.Interfaces;
public interface ICustomerRequestMapper {
    CustomerRequestEntity MapToCustomerRequestEntity(CustomerRequest customerRequest);
    CustomerRequest MapToCustomerRequest(CustomerRequestEntity customerRequestEntity);
    IList<CustomerRequest> MapToCustomerRequests(IList<CustomerRequestEntity> customerRequestEntities);
    IList<CustomerRequestEntity> MapToCustomerRequestEntities(IList<CustomerRequest> customerRequests);
}

