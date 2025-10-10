using Domain.Interfaces.Notifications;
using Domain.Notifications;
using Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Commands.Handlers;

public class DeleteProductCommandHandler(ProductContext context, INotifier notifier) : IRequestHandler<DeleteProductCommand>
{
    private readonly ProductContext _context = context;
    private readonly INotifier _notifier = notifier;

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (product is null)
        {
            _notifier.Handle(new Notification("Esse produto não existe na nossa base de dados."));
            return;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
