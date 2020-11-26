using CQRS.Application.Command.Request;
using CQRS.Domain.Employee;
using CQRS.Domain.Interface.EmployeeRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Command.Handler
{
    public class EmployeeCommandHandler : IRequestHandler<EmployeeCreateCommand, String>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task<string> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employees(request.Name, request.LastName, request.Position);
            _employeeRepository.Post(employee);

            return Task.FromResult("Criado com sucesso!");
        }
    }
}
