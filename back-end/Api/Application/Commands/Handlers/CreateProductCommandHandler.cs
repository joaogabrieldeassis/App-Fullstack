using Domain.Entities;
using Infraestructure.Context;
using MediatR;

namespace Api.Application.Commands.Handlers;

public class CreateProductCommandHandler(ProductContext context) : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly ProductContext _context = context;

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name,
                                  request.Price,
                                  request.Description);

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}