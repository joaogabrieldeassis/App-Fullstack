namespace Infraestructure.Context;

public class ProductContext : DbContext
{
    public ProductContext() { }
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);
    }
}