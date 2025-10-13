using Api.Application.Dtos;
using Api.Application.Queries.Dtos;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Api.Application.Queries;

public class GetByIdProductQuerie(IProductRepository repository) : IRequestHandler<GetByIdProductQuerieCommand, ProductDto?>
{
    private readonly IProductRepository _repository = repository;

    public async Task<ProductDto?> Handle(GetByIdProductQuerieCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if (product == null) return null;

        return new ProductDto(product.Id,
                              product.Name,
                              product.Price,
                              product.Description,
                              product.Quantity,
                              product.CreateDate);
    }
}