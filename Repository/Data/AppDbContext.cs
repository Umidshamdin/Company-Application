using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public class AppDbContext<T>
    {
        public static List<T> datas { get; }

        static AppDbContext()
        {
            datas = new List<T>();
        }
    }
}
