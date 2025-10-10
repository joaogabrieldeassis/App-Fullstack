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
        var id = request.Id;
        var sql = $"SELECT Id, Name, Price FROM Products WHERE Id = {id}";

        return await _context.Database
                     .SqlQuery<ProductDto?>($"{sql}") 
                     .FirstOrDefaultAsync(cancellationToken);
    }
}