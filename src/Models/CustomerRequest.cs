namespace ShopStore.Models;

public class CustomerRequest {

    public int Id { get; set; }
    public DateTime RequestDate { get; set; }
    public int RequestedQuantity { get; set; }
    public double ShippingPrice { get; set; }
    public double TotalPrice  {get {return ShippingPrice + Product.Price;}}
    public string PayementMethod { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public SellingStatus Status { get; set; }

}