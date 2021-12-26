using CompanyApplication.Conroller;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;

namespace CompanyApplication
{
    class Program
    {
        private static object _companyServices;

        static void Main(string[] args)
        {
            Helpers.WriteToConsole(ConsoleColor.Blue, "Select options");
            CompanyService companyService = new CompanyService();
            CompanyController companyController = new CompanyController();
            
            while (true)
            {
                GetMenus();
                

                string selectOption = Console.ReadLine();

                int option;
                bool isTrueOption = int.TryParse(selectOption, out option);

                
                
                    switch (option)
                    {
                        case (int)MyEnums.Menus.CreateCompany:
                        companyController.Create();
                            break;
                        case (int)MyEnums.Menus.UpdateCompany:
                        companyController.Update();
                        break;

                    }
            }
        }
        private static void GetMenus()
        {
            Helpers.WriteToConsole(ConsoleColor.Magenta, "1 - CreateCompany,2 - UpdateCompany,3 - DeleteCompany,4- GetCompanyById,");
            Helpers.WriteToConsole(ConsoleColor.Magenta, "5 - GetAllCompanyByName ,6 - GetAllCompany,7 -Create Employee,");
            Helpers.WriteToConsole(ConsoleColor.Magenta, "8 -Update Employee ,9 - GetEmployeeById,10 - DeleteCompany,");
            Helpers.WriteToConsole(ConsoleColor.Magenta, "11 - GetEmployeeByAge,12 - GetAllEmployeeByCompanyId,");
        }
    }
}
