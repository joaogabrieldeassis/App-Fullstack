using Domain.Interfaces.Notifications;
using Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers;

[ApiController]
public abstract class MainController(INotifier notificador, ILogger<MainController> logger) : ControllerBase
{
    private readonly INotifier _notificador = notificador;
    private readonly ILogger _logger = logger;
    public Guid UsuarioId { get; set; }
    public bool UsuarioAutenticado { get; set; }

    protected bool OperacaoValida()
    {
        return !_notificador.HasNotification();
    }

    protected ActionResult CustomReponse(object? result = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }
        return BadRequest(new
        {
            success = false,
            errors = _notificador.GetNotifications().Select(x => x.Message)
        });
    }

    protected ActionResult CustomReponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotificarErrorModelInvalida(modelState);
        return CustomReponse();
    }

    protected void NotificarErrorModelInvalida(ModelStateDictionary modelState)
    {
        var toTakeErros = modelState.Values.SelectMany(x => x.Errors);
        foreach (var error in toTakeErros)
        {
            var receiveError = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
            NotificarErro(receiveError);
        }
    }

    protected void NotificarErro(string message)
    {
        _notificador.Handle(new Notification(message));
    }
}