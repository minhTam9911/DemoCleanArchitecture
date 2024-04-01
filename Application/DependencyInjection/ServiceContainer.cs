using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyInjection;
public static class ServiceContainer
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddScoped<IEmployeeService, EmployeeService>();
		return services;
	}
}
