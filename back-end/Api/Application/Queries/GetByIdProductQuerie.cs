using Api.Application.Dtos;
using Api.Application.Queries.Commands;
using Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Queries;

public class GetByIdProductQuerie(ProductContext context) : IRequestHandler<GetByIdProductQuerieCommand, ProductDto?>
{
    private readonly ProductContext _context = context;

    public async Task<ProductDto?> Handle(GetByIdProductQuerieCommand request, CancellationToken cancellationToken)
    {
        return await _context.Products
                     .Where(p => p.Id == request.Id)
                     .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Description))
                     .FirstOrDefaultAsync(cancellationToken);
    }
}