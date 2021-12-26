using Domain.Models;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Conroller
 {
    public class CompanyController
    {

        private CompanyService _companyService;
        private object _companyServices;
        private bool isIdTrue;
        private string newName;
        private string newAddress;

        public CompanyController()
        {
            _companyService = new CompanyService();
        }

        public void Create()
        {

            Helpers.WriteToConsole(ConsoleColor.Red, "Add Company name");
            string companyName = Console.ReadLine();
            Helpers.WriteToConsole(ConsoleColor.Magenta, "Add Company address");
            string companyAddress = Console.ReadLine();

           


            Company company = new Company()
            {
                Name = companyName,
                Address = companyAddress

            };
            var result = _companyService.Create(company);

            if (result != null)
            {
                Helpers.WriteToConsole(ConsoleColor.Yellow, $"{company.Id} - {company.Name}- {company.Address}");
            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Yellow, "Something is wrong");
            }





        }

        public void Update()
        {
            Helpers.WriteToConsole(ConsoleColor.Red, "Add Company Id");
            EnterId: string companyId = Console.ReadLine();
            int Id;
            bool isIdTrue = int.TryParse(companyId, out Id);


            if (isIdTrue)
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Add Company name");
                string newName = Console.ReadLine();
                Helpers.WriteToConsole(ConsoleColor.Magenta, "Add Company address");
                string newAddress = Console.ReadLine();






                Company company = new Company()
                {
                    Name = newName,
                    Address = newAddress

                };
                var newCompany = _companyService.Update(Id, company);
                Helpers.WriteToConsole(ConsoleColor.Yellow, $"{newCompany.Id} - {newCompany.Name}- {newCompany.Address}");
            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Yellow, "Something is wrong");
                goto EnterId;
            };



        }
        public void GetById()
        {
            Helpers.WriteToConsole(ConsoleColor.Red, "Add Company Id");
        EnterId: string companyId = Console.ReadLine();
            int Id;
            bool isIdTrue = int.TryParse(companyId, out Id);

            

            if (isIdTrue)
            {
                var company = _companyService.GetById(Id);
                if (company == null)
                {
                    Helpers.WriteToConsole(ConsoleColor.Red, "Company was not faund");
                }
                else
                {
                    Helpers.WriteToConsole(ConsoleColor.Green, $"{company.Name} - {company.Name}");
                }
            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Yellow, "Try again");
                goto EnterId;
            };
        }
    }   }  

