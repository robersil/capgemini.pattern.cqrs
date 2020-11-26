using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Command.Request
{
    public class EmployeeCreateCommand : IRequest<String>
    {
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
    }
}
