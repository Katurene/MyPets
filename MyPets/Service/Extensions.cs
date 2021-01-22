using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPets.Service
{
    public static class Extensions
    {
        public static string CutController(this string str)//метод расширения для строки
        {
            return str.Replace("Controller", "");
        }
    }
}
