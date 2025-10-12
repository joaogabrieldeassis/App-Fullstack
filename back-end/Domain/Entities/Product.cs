namespace Domain.Entities;

public class Product : Entity
{
    public Product(string name, decimal price, string description, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        Quantity = quantity;
        CreateDate = DateTime.UtcNow;
    }

    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int Quantity { get; private set; }

    public void Update(string name, decimal price, string description, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        UpdateDate = DateTime.UtcNow;
        Quantity = quantity;
    }
}