using Api.Application.Dtos;
using MediatR;

namespace Api.Application.Queries.Dtos;

public record GetByIdProductQuerieCommand(Guid Id) : IRequest<ProductDto?>;