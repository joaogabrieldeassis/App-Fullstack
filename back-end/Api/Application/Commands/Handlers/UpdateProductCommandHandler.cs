using Domain.Interfaces.Notifications;
using Domain.Notifications;
using Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Commands.Handlers;

public class UpdateProductCommandHandler(ProductContext context, INotifier notifier) : IRequestHandler<UpdateProductCommand>
{
    private readonly ProductContext _context = context;
    private readonly INotifier _notifier = notifier;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (product is null)
        {
            _notifier.Handle(new Notification("Esse produto não existe na nossa base de dados."));
            return;
        }

        product.Update(request.Name, request.Price, request.Description);
        await _context.SaveChangesAsync(cancellationToken);
    }
}