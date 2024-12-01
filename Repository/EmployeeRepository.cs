using EmployeePortal_Angular_CoreWebApi.Data;
using EmployeePortal_Angular_CoreWebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeePortal_Angular_CoreWebApi.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbCotext dbCotext;
        public EmployeeRepository(AppDbCotext dbContext)
        {
            this.dbCotext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await this.dbCotext.Employees.ToListAsync();
        }

        public async Task SaveEmployee(Employee employee)
        {
            await dbCotext.Employees.AddAsync(employee);
            await this.dbCotext.SaveChangesAsync();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var resultEmployee = await dbCotext.Employees.FindAsync(id);
            if (resultEmployee != null)
            {
                resultEmployee.Name = employee.Name;
                resultEmployee.Salary = employee.Salary;
                resultEmployee.Mobile = employee.Mobile;
                resultEmployee.Age = employee.Age;
                resultEmployee.Email = employee.Email;
                resultEmployee.Status = employee.Status;

                //dbCotext.Employees.Update(resultEmployee);
                await dbCotext.SaveChangesAsync();
                return resultEmployee;
            }
            throw new Exception("Employee Not Found");

        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await dbCotext.Employees.FindAsync(id);
            if (employee != null)
            {
                dbCotext.Employees.Remove(employee);
                await dbCotext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Employee Not Found");
            }

        }

        public async Task PatchEmployee(int id, JsonPatchDocument<Employee> employeePatch)
            {
            var employee = await dbCotext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee Not Found");
            }
            employeePatch.ApplyTo(employee);
            await dbCotext.SaveChangesAsync();
        }
    }
}