namespace ShopStore.Models;

public class Customer {

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Mobile { get; set; }
    public string FixedLine { get; set; }
    public UserInfo UserInfo { get; set; }
}

