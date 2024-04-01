using Application.Commands.EmployeeCommand.Create;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.EmployeeHandler;
public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ServiceResponse>
{
	private readonly AppDbContext appDbContext;

	public CreateEmployeeHandler(AppDbContext appDbContext) {
		this.appDbContext = appDbContext;
	}

	public async Task<ServiceResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var check = await appDbContext.Employees.Where(x => x.Email == request.Employee.Email).FirstOrDefaultAsync();
		if(check!=null)
		{
			return new ServiceResponse(false, "Email already");
		}
		await appDbContext.Employees.AddAsync(request.Employee);
		await appDbContext.SaveChangesAsync();
		return new ServiceResponse(true, "Inserted");
	}
}
