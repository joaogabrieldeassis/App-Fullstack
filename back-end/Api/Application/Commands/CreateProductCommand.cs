using MediatR;

namespace Api.Application.Commands;

public record CreateProductCommand(string Name, decimal Price, string Description, int Quantity) : IRequest;