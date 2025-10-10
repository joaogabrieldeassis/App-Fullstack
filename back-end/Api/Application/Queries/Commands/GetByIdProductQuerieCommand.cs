using Api.Application.Dtos;
using MediatR;

namespace Api.Application.Queries.Commands;

public record GetByIdProductQuerieCommand(Guid Id) : IRequest<ProductDto?>;