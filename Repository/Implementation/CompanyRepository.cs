using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Create(Company entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new CustomException("Entity is null");
                }
                else
                {
                    AppDbContext<Company>.data.Add(entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Company entity)
        {
            try
            {
                AppDbContext<Company>.data.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Company Get(Predicate<Company> predicate = null)
        {
            return predicate==null ? AppDbContext<Company>.data[0]: AppDbContext<Company>.data.Find(predicate);
        }

        public List<Company> GetAll(Predicate<Company> predicate)
        {
            return predicate == null ? AppDbContext<Company>.data : AppDbContext<Company>.data.FindAll(predicate);
        }

        public bool Update(Company entity)
        {
            try
            {
                var company = Get(m => m.Id == entity.Id);
                if (company != null)
                {
                    if (!string.IsNullOrEmpty(entity.Name))
                    {
                        company.Name = entity.Name;
                    }

                    if (!string.IsNullOrEmpty(entity.Address))
                    {
                        company.Address = entity.Address;
                    }
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
