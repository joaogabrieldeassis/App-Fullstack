using MediatR;

namespace Api.Application.Commands;

public record UpdateProductCommand(Guid Id, string Name, decimal Price, string Description) : IRequest;