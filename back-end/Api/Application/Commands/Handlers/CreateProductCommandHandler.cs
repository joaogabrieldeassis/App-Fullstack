using Domain.Entities;
using Domain.Interfaces.Notifications;
using Domain.Validations;
using Infraestructure.Context;
using MediatR;

namespace Api.Application.Commands.Handlers;

public class CreateProductCommandHandler(ProductContext context,
                                         INotifier notifier) : CommandHandlerBase(notifier), IRequestHandler<CreateProductCommand, Guid?>
{
    private readonly ProductContext _context = context;

    public async Task<Guid?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name,
                                  request.Price,
                                  request.Description);

        if (!TheEntityIsValid(new ProductValidation(), product)) return null;

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}