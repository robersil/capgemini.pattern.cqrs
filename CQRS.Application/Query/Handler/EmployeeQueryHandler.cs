using CQRS.Application.Query.Request;
using CQRS.Application.Query.Response;
using CQRS.Domain.Interface.EmployeeRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Query.Handler
{
    public class EmployeeQueryHandler : IRequestHandler<EmployeeGetRequest, EmployeeGetResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeGetResponse> Handle(EmployeeGetRequest request, CancellationToken cancellationToken)
        {
            var employee = _employeeRepository.Get(request.Id);

            var response = new EmployeeGetResponse() { Name = employee.Name, LastName = employee.LastName, Position = employee.Position};

            return response;
        }
    }
}