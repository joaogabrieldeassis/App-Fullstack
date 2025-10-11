using Domain.Validations;
using Test.Bogus;

namespace Test;

public class ProductTest
{
    private readonly ProductValidation _validator;

    public ProductTest()
    {
        _validator = new ProductValidation();
    }

    [Fact]
    public void Product_IsValid_ItShouldReturnTrueBecauseTheProductIsValid()
    {
        // Arrange
        var product = CreateProduct.GenerateProductValid(1).FirstOrDefault();

        // Act
        var result = _validator.Validate(product!);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Product_IsInvalid_ItShouldReturnFalseBecauseTheProductHasInvalid()
    {
        // Arrange
        var product = CreateProduct.GenerateProductInValid(1).FirstOrDefault();

        // Act
        var result = _validator.Validate(product!);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(4, result.Errors.Count);
    }
}