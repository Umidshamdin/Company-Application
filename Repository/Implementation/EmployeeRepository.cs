using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity)
        {
            try
            {
                if (entity == null)
                    throw new CustomException("Entity is null");
                AppDbContext<Employee>.datas.Add(entity);
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }



        }

        bool IRepository<Employee>.Delete(Employee entity)
        {

            try
            {
                AppDbContext<Employee>.datas.Remove(entity);
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Employee Get(Predicate<Employee> filter)
        {
            return filter == null ? AppDbContext<Employee>.datas[0] : AppDbContext<Employee>.datas.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> filter)
        {
            return filter == null ? AppDbContext<Employee>.datas : AppDbContext<Employee>.datas.FindAll(filter);
        }

        public bool Update(Employee entity)
        {

            try
            {
                var employee = Get(m => m.Id == entity.Id);
                if (employee != null)
                {
                    if (!string.IsNullOrEmpty(entity.Name))
                        employee.Name = entity.Name;
                    if (!string.IsNullOrEmpty(entity.SurName))
                        employee.SurName = entity.SurName;
                    if (!string.IsNullOrEmpty(entity.Age.ToString()))
                        employee.Age = entity.Age;

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
