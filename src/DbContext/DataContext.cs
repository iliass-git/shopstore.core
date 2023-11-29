namespace ShopStore.DbContext;
using Microsoft.EntityFrameworkCore;
using ShopStore.DbContext.Entities;


public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<UserInfoEntity> UserInfos { get; set; }
    public DbSet<CustomerRequestEntity> CustomerRequests { get; set; }
}