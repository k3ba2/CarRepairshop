using Microsoft.Extensions.DependencyInjection;
using CarRepairshop.Application.Mappings;
using MediatR;
using CarRepairshop.Application.CarRepairshop.Queries.GetAllCarRepairshop;
using CarRepairshop.Application.CarRepairshop.Commands.CreateCarRepairshop;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CarRepairshop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CarRepairshopMappingProfile));

            services.AddMediatR(typeof(GetAllCarRepairshopQueryHandler));

            services.AddValidatorsFromAssemblyContaining<CreateCarRepairshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        }
    }
}
