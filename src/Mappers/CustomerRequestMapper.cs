using ShopStore.Models;
using ShopStore.DbContext.Entities;
using ShopStore.Mappers.Interfaces;
namespace ShopStore.Mapper;

public class CustomerRequestMapper : ICustomerRequestMapper{

    private readonly ICustomerMapper _customerMapper;
    private readonly IProductMapper _productMapper;
    public CustomerRequestMapper(ICustomerMapper customerMapper, IProductMapper productMapper){
        _customerMapper = customerMapper;
        _productMapper = productMapper;

    }
    public CustomerRequestEntity MapToCustomerRequestEntity(CustomerRequest customerRequest){
        return new CustomerRequestEntity{
            Id = customerRequest.Id,
            RequestDate = customerRequest.RequestDate,
            RequestedQuantity = customerRequest.RequestedQuantity,
            ShippingPrice = customerRequest.ShippingPrice,
            PayementMethod = customerRequest.PayementMethod,
            Customer = _customerMapper.MapToCustomerEntity(customerRequest.Customer),
            Product = _productMapper.MapToProductEntity(customerRequest.Product),
            Status =  customerRequest.Status
        };
    }
    public CustomerRequest MapToCustomerRequest(CustomerRequestEntity customerRequestEntity){
        return new CustomerRequest{
            Id = customerRequestEntity.Id,
            RequestDate = customerRequestEntity.RequestDate,
            RequestedQuantity = customerRequestEntity.RequestedQuantity,
            ShippingPrice = customerRequestEntity.ShippingPrice,
            PayementMethod = customerRequestEntity.PayementMethod,
            Customer = _customerMapper.MapToCustomer(customerRequestEntity.Customer),
            Product = _productMapper.MapToProduct(customerRequestEntity.Product),
            Status =  customerRequestEntity.Status
        };
    }
    public IList<CustomerRequest> MapToCustomerRequests(IList<CustomerRequestEntity> customerRequestEntities){
        IList<CustomerRequest> customerRequests = new List<CustomerRequest>();
        foreach(CustomerRequestEntity customerRequestEntity in customerRequestEntities){
            customerRequests.Add(MapToCustomerRequest(customerRequestEntity));
        }
        return customerRequests;
    }
    public IList<CustomerRequestEntity> MapToCustomerRequestEntities(IList<CustomerRequest> customerRequests){
        IList<CustomerRequestEntity> customerRequestEntities = new List<CustomerRequestEntity>();
        foreach(CustomerRequest customerRequest in customerRequests){
            customerRequestEntities.Add(MapToCustomerRequestEntity(customerRequest));
        }
        return customerRequestEntities;
    }
}