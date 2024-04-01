using Application.Contracts;
using Infrastructure.Data;
using Infrastructure.Handlers.EmployeeHandler;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection;
public static class ServiceContainer
{

	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{

		services.AddDbContext<AppDbContext>(
			options => options.UseLazyLoadingProxies().UseSqlServer(configuration["ConnectionStrings:Default"]),
			ServiceLifetime.Scoped
			);
		services.AddScoped<IEmployeeReponsitory, EmployeeReponsitory>();
		services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(GetListEmployeeHandler).Assembly));
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetByIdEmployeeHandler).Assembly));
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeHandler).Assembly));
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateEmployeeHandler).Assembly));
		services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(DeleteEmployeeHandler).Assembly));
		return services;
	}

}
