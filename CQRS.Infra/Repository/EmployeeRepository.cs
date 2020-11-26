using CQRS.Domain.Employee;
using CQRS.Domain.Interface.EmployeeRepository;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CQRS.Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("stringConnection");
        }
        public Employees Get(int id)
        {
            var connection = new SqlConnection(_connectionString);
           
            var employees = connection.Query<Employees>("SELECT [id]" +
                                                         ", [Name]" +
                                                         ", [LastName]" +
                                                         ", [Position]" +
                                                         $"FROM [dbo].[Employees] WHERE [id] = {id}");

            return employees.FirstOrDefault();
        }

        public void Post(Employees employees)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into Employees (Name, LastName, Position) values (@name, @lastName, @position)";

            connection.Execute(query, new { name = employees.Name, lastName = employees.LastName, position = employees.Position });
        }
    }
}