using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class EmployeeService
    {
        //TODO: In-memory collection to store employees (replace with API Endpoint)
        private readonly List<Employees?> _employees = [];

        public EmployeeService()
        {
            // Initialize some dummy data
            _employees.Add(new Employees
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                HireDate = DateTime.Now,
                EmployeePhones = [],
                EmployeeAddresses = []
            });
            _employees.Add(new Employees
            {
                EmployeeId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                HireDate = DateTime.Now,
                EmployeePhones = [],
                EmployeeAddresses = []
            });
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        public List<Employees?> GetEmployees()
        {
            return _employees;
        }

        /// <summary>
        /// Get employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employees? GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e != null && e.EmployeeId == id);
        }

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="employee"></param>
        public void CreateEmployee(Employees? employee)
        {
            // Generate a unique ID (replace with database auto-increment)
            if (employee == null) return;
            employee.EmployeeId = _employees.Count != 0 ? _employees.Max(e => e?.EmployeeId ?? 0) + 1 : 1;
            _employees.Add(employee);
        }

        /// <summary>
        /// Update an existing employee
        /// </summary>
        /// <param name="employee"></param>
        public void UpdateEmployee(Employees employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e != null && e.EmployeeId == employee.EmployeeId);
            if (existingEmployee == null) return;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.HireDate = employee.HireDate;
            // Update other properties as needed
        }

        /// <summary>
        /// Delete an employee by ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            var employeeToDelete = _employees.FirstOrDefault(e => e != null && e.EmployeeId == id);
            if (employeeToDelete != null)
            {
                _employees.Remove(employeeToDelete);
            }
        }
    }
}
