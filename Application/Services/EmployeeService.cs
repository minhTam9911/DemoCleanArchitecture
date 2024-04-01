using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class EmployeeService : IEmployeeService
{

	private readonly HttpClient httpClient;
	public EmployeeService(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public async Task<ServiceResponse> DeleteAsync(int id)
	{
		var data = await httpClient.DeleteAsync($"/api/Employees/{id}");
		var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
		return response!;
	}

	public async Task<Employee> GetAsync(int id)
	{
		var data = await httpClient.GetFromJsonAsync<Employee>($"/api/Employees/{id}");
		return data!;
	}

	public async Task<List<Employee>> GetListAsync()
	{
		var data = await httpClient.GetFromJsonAsync<List<Employee>>("/api/Employees");
		return data;
	}

	public async Task<ServiceResponse> InsertAsync(Employee employee)
	{
		var data = await httpClient.PostAsJsonAsync("/api/Employees",employee);
		var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
		return response!;
	}

	public async Task<ServiceResponse> UpdateAsync(Employee employee)
	{
		var data = await httpClient.PutAsJsonAsync("/api/Employees", employee);
		var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
		return response!;
	}
}
