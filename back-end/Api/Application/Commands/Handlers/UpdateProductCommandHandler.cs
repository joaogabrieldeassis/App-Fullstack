using Domain.Interfaces.Notifications;
using Domain.Validations;
using Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Commands.Handlers;

public class UpdateProductCommandHandler(ProductContext context, INotifier notifier) : CommandHandlerBase(notifier), IRequestHandler<UpdateProductCommand>
{
    private readonly ProductContext _context = context;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (product is null)
        {
            Notify("Esse produto não existe na nossa base de dados.");
            return;
        }

        product.Update(request.Name, request.Price, request.Description, request.Quantity);
        if (!TheEntityIsValid(new ProductValidation(), product)) return;

        await _context.SaveChangesAsync(cancellationToken);
    }
}