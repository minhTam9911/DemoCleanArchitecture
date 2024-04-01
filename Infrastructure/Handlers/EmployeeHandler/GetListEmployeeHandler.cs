using Application.Queries.EmployeeQuery;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.EmployeeHandler;
public class GetListEmployeeHandler : IRequestHandler<GetListEmployeeQuery, List<Employee>>
{
	private readonly AppDbContext appDbContext;
	public GetListEmployeeHandler(AppDbContext appDbContext)
	{
		this.appDbContext = appDbContext;
	}

	public async Task<List<Employee>> Handle(GetListEmployeeQuery request, CancellationToken cancellationToken)
	{
		return await appDbContext.Employees.AsNoTracking().ToListAsync(cancellationToken:cancellationToken);
	}
}
