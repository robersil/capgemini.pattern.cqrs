using CQRS.Domain.Interface.EmployeeRepository;
using CQRS.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace CQRS.CrossCutting.DI
{
    public static class DIModule
    {
        public static void ConfigureClassesDI(IServiceCollection service)
        {
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();            
        }
    }
}
