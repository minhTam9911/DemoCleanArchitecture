using Application.Commands.EmployeeCommand.Delete;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.EmployeeHandler;
public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ServiceResponse>
{
	private readonly AppDbContext appDbContext;

	public DeleteEmployeeHandler(AppDbContext appDbContext)
	{
		this.appDbContext = appDbContext;
	}
	public async Task<ServiceResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
	{
		var employee = await appDbContext.Employees.FindAsync(request.Id);
		if (employee == null)
		{
			return new ServiceResponse(false, "User not found");
		}
		appDbContext.Employees.Remove(employee);
		await appDbContext.SaveChangesAsync();
		return new ServiceResponse(true, "Deleted");
	}
}
