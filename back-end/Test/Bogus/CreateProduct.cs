using Bogus;
using Domain.Entities;

namespace Test.Bogus;

public static class CreateProduct
{
    public static List<Product> GenerateProductValid(int quantity = 1)
    {
        var faker = new Faker<Product>()
            .CustomInstantiator(f => new Product(
                name: f.Commerce.ProductName(),
                price: f.Random.Decimal(10, 2000), 
                description: f.Commerce.ProductDescription()
            ));

        return faker.Generate(quantity);
    }

    public static List<Product> GenerateProductInValid(int quantity = 1)
    {
        var faker = new Faker<Product>()
            .CustomInstantiator(f => new Product(
                name: string.Empty,
                price: 0, 
                description: f.Commerce.ProductDescription()
            ));

        return faker.Generate(quantity);
    }
}