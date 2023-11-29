namespace ShopStore.DbContext.Entities;
using ShopStore.Enums;

public class CustomerRequestEntity {

    public int Id { get; set; }
    public DateTime RequestDate { get; set; }
    public int RequestedQuantity { get; set; }
    public double ShippingPrice { get; set; }
    public double TotalPrice  {get {return ShippingPrice + Product.Price;}}
    public string PayementMethod { get; set; }
    public CustomerEntity Customer { get; set; }
    public ProductEntity Product { get; set; }
    public SellingStatus Status { get; set; }

}