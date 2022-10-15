using Domain.Models;
using Repository.Implementation;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private CompanyRepository _companyRepository { get; }
        private EmployeeRepository _employeeRepository { get; }
        private int count { get; set; }
        public EmployeeService()
        {
            _companyRepository = new CompanyRepository();
            _employeeRepository = new EmployeeRepository();
        }
        public Employee Create(Employee model, int companyId)
        {
            try
            {
                Company company = _companyRepository.Get(m => m.Id == companyId);
                if (company == null) return null;
                model.Id = count;
                model.Company = company;
                _employeeRepository.Create(model);
                count++;
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Employee GetById(int employeeId)
        {
            try
            {
                Employee employee = _employeeRepository.Get(m => m.Id == employeeId);

                if (employee == null)
                {
                    return null;
                }
                else
                {
                    return _employeeRepository.Get(m => m.Id == employeeId);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
        public List<Employee> GetByAge(int employeeAge)
        {
            try
            {
                return _employeeRepository.GetAll(m => m.Age == employeeAge);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public Employee Update(int id, Employee entity)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                entity.Id = employee.Id;
                _employeeRepository.Update(entity);
                return entity;
            }
            else
            {
                return null;
            }
        }
        public List<Employee> GetAllById(int id)
        {
            return _employeeRepository.GetAll(m => m.Company.Id == id);
        }
    }
}
