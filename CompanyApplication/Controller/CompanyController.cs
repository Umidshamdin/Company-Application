using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class CompanyController
    {
        private CompanyService _companyService;
        public CompanyController()
        {
            _companyService = new CompanyService();
        }
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.Gray, "Add Company Name:");
            string companyName = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Gray, "Add Company Address:");
            string companyAddress = Console.ReadLine();

            Company company = new Company
            {
                Name = companyName,
                Address = companyAddress
            };

            var result = _companyService.Create(company);
            if (result != null)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{company.Id}{" - "}{company.Name} Company created");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Green, "Sometimes is wrong");
            }
        }

        public void GetCompanyById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company id");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);
            if (isTrueId)
            {
                var companyResult = _companyService.GetById(id);
                if (companyResult == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"Company Name: {companyResult.Name}{"  "} Company Address: {companyResult.Address}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add Company Id");

            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);

            if (isTrueId)
            {
                var company = _companyService.GetById(id);
                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found");
                    goto EnterId;
                }
                else
                {
                    _companyService.Delete(company);
                    Helper.WriteToConsole(ConsoleColor.Green, "Company is deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again enter id");
                goto EnterId;
            }
        }
        public void GetAll()
        {
            var companies = _companyService.GetAll();

            foreach (var item in companies)
            {
                Console.WriteLine(item.Id + "-" + item.Name + "-" + item.Address);
            }
        }
        public void GetAllCompanyByName()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add Company Name");
            string companyName = Console.ReadLine();
            var companies = _companyService.GetAll();
            foreach (var item in companies)
            {
                if (item.Name==companyName)
                {
                    var result = _companyService.GetAllByName(companyName);
                    foreach (var companyNames in result)
                    {
                        Console.WriteLine(companyNames.Id + "-" + companyNames.Name + "-" + companyNames.Address);
                        return;
                    }
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "There is not found this company");
                    return;
                }
            }                   
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company id");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add new company name");
            string newName = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add new company address");
            string newAddress = Console.ReadLine();

            if (isTrueId)
            {
                Company company = new Company
                {
                    Name = newName,
                    Address=newAddress
                };

                Company newCompany = _companyService.Update(id, company);
                Helper.WriteToConsole(ConsoleColor.Green, $"New Company Name: {newCompany.Name}{" "}New Company Address: {newCompany.Address}");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again");
                goto EnterId;
            }
        }
    }
}
