using Api.Application.Dtos;
using MediatR;

namespace Api.Application.Queries.Dtos;

public record GetAllProductQuerieCommand : IRequest<IEnumerable<ProductDto>>;