using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts;
public interface IEmployeeReponsitory
{
	Task<ServiceResponse> InsertAsync(Employee employee);
	Task<ServiceResponse> UpdateAsync(Employee employee);
	Task<ServiceResponse> DeleteAsync(int id);
	Task<List<Employee>> GetListAsync();
	Task<Employee> GetAsync(int id);
}
