using Api.Application.Dtos;
using MediatR;

namespace Api.Application.Queries.Commands;

public record GetAllProductQuerieCommand : IRequest<IEnumerable<ProductDto>>;