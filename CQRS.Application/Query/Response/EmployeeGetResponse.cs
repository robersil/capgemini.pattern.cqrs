using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Application.Query.Response
{
    public class EmployeeGetResponse
    {
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
    }
}
