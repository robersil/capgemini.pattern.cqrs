using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Domain.Employee;

namespace CQRS.Domain.Interface.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Employees Get(int id);
        void Post(Employees employees);
    }
}