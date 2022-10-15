using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public class MyEnum
    {
        public enum Menus
        {
            CreateCompany=1,
            UpdateCompany,
            DeleteCompany,
            GetCompanyById,
            GetAllCompanyByName,
            GetAllCompany,
            CreateEmployee,
            UpdateEmployee,
            GetEmployeeById,
            DeleteEmployee,
            GetEmployeeByAge,
            GetAllEmployeeByCompanyId
        }
    }
}
