using Application.Commands.EmployeeCommand.Update;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.EmployeeHandler;
public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResponse>
{
	private readonly AppDbContext appDbContext;

	public UpdateEmployeeHandler(AppDbContext appDbContext)
	{
		this.appDbContext = appDbContext;
	}

	public async Task<ServiceResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		appDbContext.Entry(request.Employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		await appDbContext.SaveChangesAsync();
		return new ServiceResponse(true, "Updated");
	}
}
