using Domain.Models;
using Repository.Implementation;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {

        private CompanyRepository _companyRepository;
        private int count { get; set; } 
        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
                
        }

        public Company Create(Company model)
        {
            model.Id = count;
            count++;
            _companyRepository.Create(model);
            return model;



        }
        public Company GetById(int Id)
        {
            return _companyRepository.Get(m => m.Id == Id);
        }
        public Company Update(int Id, Company model)
        {
            var company = GetById( Id);
            model.Id = company.Id;
            _companyRepository.Update(model);

            return model;
        }

        void ICompanyService.Delete(Company model)
        {
            throw new NotImplementedException();
        }

        Company ICompanyService.Get(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        List<Company> ICompanyService.GetAll(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }
    }
}
