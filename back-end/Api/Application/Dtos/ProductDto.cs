namespace Api.Application.Dtos;

public record ProductDto(Guid Id, string Name, decimal Price, string Description, int Quantity, DateTime CreateDate);