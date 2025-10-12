using Api.Application.Commands;
using Api.Application.Commands.Handlers;
using Api.Application.Dtos;
using Api.Application.Queries;
using Api.Application.Queries.Commands;
using Domain.Entities;
using Domain.Interfaces.Notifications;
using Domain.Interfaces.Repositories;
using Domain.Notifications;
using Infraestructure.Context;
using Infraestructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ProgramExtension
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        services.AddMediator();
        services.AddDbContext();
        services.ResolveDepenciInjection();

        return services;
    }

    private static IServiceCollection ResolveDepenciInjection(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateProductCommand, Guid?>, CreateProductCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateProductCommand>, UpdateProductCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
        services.AddScoped<IRequestHandler<GetByIdProductQuerieCommand, ProductDto?>, GetByIdProductQuerie>();
        services.AddScoped<IRequestHandler<GetAllProductQuerieCommand, IEnumerable<ProductDto>>, GetAllProductQuerie>();
        services.AddScoped<INotifier, Notifier>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("DbProducts"));

        return services;
    }

    public static void CreateDataForTest(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ProductContext>();

        if (!context.Products.Any())
        {
            context.Products.AddRange(
            [
                new Product("Camisa", 109.50m, "Camiseta Peruana fabricada no Peru", 8),
                new Product("Tênis", 229.89m, "Tênis para esportes", 3),
            ]);

            context.SaveChanges();
        }
    }
}