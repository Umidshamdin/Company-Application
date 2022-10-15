using CompanyApplication.Controller;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyController companyController = new CompanyController();
            EmployeeController employeeController = new EmployeeController();

            while (true)
            {
                Menus();
                string selectOption = Console.ReadLine();
                int option;
                bool isTrueOption = int.TryParse(selectOption, out option);
                if (isTrueOption)
                {
                    switch (option)
                    {
                        case (int)MyEnum.Menus.CreateCompany:
                            companyController.Create();
                            break;
                        case (int)MyEnum.Menus.UpdateCompany:
                            companyController.Update();
                            break;
                        case (int)MyEnum.Menus.DeleteCompany:
                            companyController.Delete();
                            break;
                        case (int)MyEnum.Menus.GetCompanyById:
                            companyController.GetCompanyById();
                            break;
                        case (int)MyEnum.Menus.GetAllCompanyByName:
                            companyController.GetAllCompanyByName();
                            break;
                        case (int)MyEnum.Menus.GetAllCompany:
                            companyController.GetAll();
                            break;
                        case (int)MyEnum.Menus.CreateEmployee:
                            employeeController.Create();
                            break;
                        case (int)MyEnum.Menus.UpdateEmployee:
                            employeeController.Update();
                            break;
                        case (int)MyEnum.Menus.GetEmployeeById:
                            employeeController.GetById();
                            break;
                        case (int)MyEnum.Menus.DeleteEmployee:
                            employeeController.Delete();
                            break;
                        case (int)MyEnum.Menus.GetEmployeeByAge:
                            employeeController.GetByAge();
                            break;
                        case (int)MyEnum.Menus.GetAllEmployeeByCompanyId:
                            employeeController.GetAll();
                            break;
                    }
                }
            }
        }
        private static void Menus()
        {
            Helper.WriteToConsole(ConsoleColor.Gray, "Please Select option");
            Helper.WriteToConsole(ConsoleColor.Cyan, "1 - Create Company       4 - Get Company By Id        7 - Creat Employee         10 - Delete Employee");
            Helper.WriteToConsole(ConsoleColor.Cyan, "2 - Update Company      5- Get Company by Name       8 - UpdateEmployee         11 - Get Employee By Age");
            Helper.WriteToConsole(ConsoleColor.Cyan, "3 - Delete Company      6 - Get All Company          9 - Get Employee By Id     12 - Get All Employee By Company Id");
        }
    }
}
