using Application.Queries.EmployeeQuery;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.EmployeeHandler;
public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeQuery, Employee>
{
	private readonly AppDbContext appDbContext;

	public GetByIdEmployeeHandler(AppDbContext appDbContext)
	{
		this.appDbContext = appDbContext;
	}

	public async Task<Employee> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
	{
		return await appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
	}
}
