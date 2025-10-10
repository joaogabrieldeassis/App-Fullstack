using MediatR;

namespace Api.Application.Commands;

public record DeleteProductCommand(Guid Id) : IRequest;