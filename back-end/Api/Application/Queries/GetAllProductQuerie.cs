using Api.Application.Dtos;
using Api.Application.Queries.Commands;
using Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Queries;

public class GetAllProductQuerie(ProductContext context) : IRequestHandler<GetAllProductQuerieCommand, IEnumerable<ProductDto>>
{
    private readonly ProductContext _context = context;

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuerieCommand request, CancellationToken cancellationToken)
    {
        return await _context.Products
                     .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Description))
                     .ToListAsync(cancellationToken);
    }
}