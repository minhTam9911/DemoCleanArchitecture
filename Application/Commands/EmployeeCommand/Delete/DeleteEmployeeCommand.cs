using Application.DTOs;
using MediatR;

namespace Application.Commands.EmployeeCommand.Delete;
public class DeleteEmployeeCommand : IRequest<ServiceResponse>
{
	public int Id { get; set; }
}
