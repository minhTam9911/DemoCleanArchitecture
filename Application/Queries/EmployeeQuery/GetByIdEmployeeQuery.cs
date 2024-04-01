﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.EmployeeQuery;
public class GetByIdEmployeeQuery : IRequest<Employee>
{
	public int Id { get; set; }
}
