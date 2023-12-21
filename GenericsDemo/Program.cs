using GenericsDemo.Data;
using GenericsDemo.Entities;
using GenericsDemo.Repositories;

SqlRepository<Employee> employeeRepository = new(new StorageAppDbContext());

AddEmployees(employeeRepository);
AddManager(employeeRepository);
GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

ListRepository<Organization> organizationRepository = new();
AddOrganizations(organizationRepository);
WriteAllToConsole(organizationRepository);


Console.ReadLine();
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items) 
    { 
        Console.WriteLine(item);
    }
}
static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Julia" });
    employeeRepository.Add(new Employee { FirstName = "Ana" });
    employeeRepository.Add(new Employee { FirstName = "Thomas" });
    employeeRepository.save();
}
static void AddManager(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Sara" });
    managerRepository.Add(new Manager { FirstName = "Henry" });
    managerRepository.save();
}
static void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetByID(2);
    Console.WriteLine($"Employee with id 2: {employee.FirstName}");
}
static void AddOrganizations(IRepository<Organization> organizationRepository)
{
    organizationRepository.Add(new Organization { Name = "open.ai" });
    organizationRepository.Add(new Organization { Name = "Globomantics" });
    organizationRepository.save();
}

