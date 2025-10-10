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
        const string query = "SELECT Id, Name, Price FROM Products";

        return await _context.Database
                     .SqlQuery<ProductDto>($"{query}")
                     .ToListAsync(cancellationToken);
    }
}