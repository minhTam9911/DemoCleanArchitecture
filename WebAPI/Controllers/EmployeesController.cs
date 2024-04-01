using Application.Commands.EmployeeCommand.Create;
using Application.Commands.EmployeeCommand.Delete;
using Application.Commands.EmployeeCommand.Update;
using Application.Contracts;
using Application.Queries.EmployeeQuery;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
	private readonly IEmployeeReponsitory employeeReponsitory;
	private readonly IMediator mediator;

	public EmployeesController(IEmployeeReponsitory employeeReponsitory, IMediator mediator)
	{
		this.employeeReponsitory = employeeReponsitory;
		this.mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetList()
	{
		var data = await mediator.Send(new GetListEmployeeQuery());
		return Ok(data);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		var data = await mediator.Send(new GetByIdEmployeeQuery { Id = id});
		return Ok(data);
	}


	[HttpPost]
	public async Task<IActionResult> Insert([FromBody] Employee employeeDto)
	{
		var result = await mediator.Send(new CreateEmployeeCommand { Employee = employeeDto});
		return Ok(result);
	}

	[HttpPut]
	public async Task<IActionResult> Update([FromBody] Employee employeeDto)
	{
		var result = await mediator.Send(new UpdateEmployeeCommand { Employee = employeeDto });
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var result = await mediator.Send(new DeleteEmployeeCommand { Id = id });
		return Ok(result);
	}

}