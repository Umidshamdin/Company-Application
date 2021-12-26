using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Employee Create(Employee model ,int companyId);
        Employee Update(int Id, Employee model);

        void Delete(Employee model);
        Employee GetById(int Id);
        Employee GetEmployeeByAge(int age);
        List<Employee> GetAllEmployeeByCompanyId(int Id);
    }
}
