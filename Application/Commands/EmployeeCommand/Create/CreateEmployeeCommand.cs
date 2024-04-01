using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Commands.EmployeeCommand.Create;
public class CreateEmployeeCommand : IRequest<ServiceResponse>
{
	public Employee? Employee { get; set; }
}
