using Api.Application.Dtos;
using Api.Application.Queries.Dtos;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Api.Application.Queries;

public class GetAllProductQuerie(IProductRepository repository) : IRequestHandler<GetAllProductQuerieCommand, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository = repository;

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuerieCommand request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Description, p.Quantity));
    }
}