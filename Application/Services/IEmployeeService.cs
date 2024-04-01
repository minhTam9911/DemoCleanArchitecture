using Application.DTOs;
using Domain.Entities;

namespace Application.Services;
public  interface IEmployeeService
{
	Task<ServiceResponse> InsertAsync(Employee employee);
	Task<ServiceResponse> UpdateAsync(Employee employee);
	Task<ServiceResponse> DeleteAsync(int id);
	Task<List<Employee>> GetListAsync();
	Task<Employee> GetAsync(int id);
}
