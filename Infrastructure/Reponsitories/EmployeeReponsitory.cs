using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;
public class EmployeeReponsitory : IEmployeeReponsitory
{

	private readonly AppDbContext appDbContext;
	public EmployeeReponsitory(AppDbContext appDbContext)
	{
		this.appDbContext = appDbContext;
	}

	public async Task<ServiceResponse> DeleteAsync(int id)
	{
		var employee = await appDbContext.Employees.FindAsync(id);
		if(employee == null)
		{
			return new ServiceResponse(false, "User not found");
		}
		appDbContext.Employees.Remove(employee);
		await appDbContext.SaveChangesAsync();
		return new ServiceResponse(true, "Deleted");

	}

	public async Task<Employee> GetAsync(int id)
	{
		var employee = await appDbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
		return employee;
	}

	public async Task<List<Employee>> GetListAsync()
	{
		var employees = await appDbContext.Employees.AsNoTracking().ToListAsync();
		return employees;
	}

	public async Task<ServiceResponse> InsertAsync(Employee employee)
	{
		await appDbContext.Employees.AddAsync(employee);
		await appDbContext.SaveChangesAsync();
		return new ServiceResponse(true, "Inserted");
	}

	public async Task<ServiceResponse> UpdateAsync(Employee employee)
	{
		appDbContext.Entry(employee).State = EntityState.Modified;
		await appDbContext.SaveChangesAsync();
		return new ServiceResponse(true, "Updated");
	}
}
