using Domain.Models;
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
            throw new NotImplementedException();
        }

        public bool Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public Company Get(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
