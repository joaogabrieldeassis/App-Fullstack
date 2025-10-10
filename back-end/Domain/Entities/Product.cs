namespace Domain.Entities;

public class Product : Entity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Description { get; private set; } = string.Empty;

    public void Update(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
        UpdateDate = DateTime.UtcNow;
    }
}