namespace Infraestructure.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("varchar(1000)");

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.CreationDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(x => x.UpdateDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder.ToTable("Products");
    }
}