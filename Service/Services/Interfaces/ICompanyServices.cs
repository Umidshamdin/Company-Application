using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface ICompanyService
    {
        Company Create(Company model);
        Company Update(int Id,Company model);

        void Delete(Company model);
        Company Get(Predicate<Company> filter);
        List<Company> GetAll(Predicate<Company> filter);
        
    }
}
