using CQRS.Application.Query.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Query.Request
{
    public class EmployeeGetRequest :IRequest<EmployeeGetResponse>
    {
        public int Id { get; set; }
    }
}
