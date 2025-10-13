using Api.Application.Commands;
using Api.Application.Queries.Dtos;
using Domain.Interfaces.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class ProductController(IMediator mediator,
                               INotifier notificador,
                               ILogger<MainController> logger) : MainController(notificador, logger)
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await _mediator.Send(new GetAllProductQuerieCommand());
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var product = await _mediator.Send(new GetByIdProductQuerieCommand(id));
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return CustomReponse();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(UpdateProductCommand command)
    {
        await _mediator.Send(command);
        return CustomReponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return CustomReponse();
    }
}