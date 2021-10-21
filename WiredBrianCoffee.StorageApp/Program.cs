using System;
using WiredBrianCoffee.StorageApp.Data;
using WiredBrianCoffee.StorageApp.Entities;
using WiredBrianCoffee.StorageApp.Repositories;

namespace WiredBrianCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {           
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.itemAdded += EmployeeRepository_itemAdded;

            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);
            
            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);


            Console.ReadLine();
        }

        private static void EmployeeRepository_itemAdded(object? sender, Employee e)
        {
             Console.WriteLine($"Employee added => {e.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { FirstName = "Catalina" });
            managerRepository.Add(new Manager { FirstName = "Adrian" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Andrea" },
                new Employee { FirstName = "Ema" },
                new Employee { FirstName = "Clara" }
            };
            employeeRepository.AddBatch(employees);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "Pluralsight" },
                new Organization { Name = "Valkimia" },
                new Organization { Name = "Globomantics" },
            };
            organizationRepository.AddBatch(organizations);
                       
        }
    }
}
