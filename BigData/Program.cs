using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF6Model.Service;
using EF6Model;

namespace BigData
{
    class Program
    {
        static void Main(string[] args)
        {
            new UserService().BulkInsert();

            Console.WriteLine("ok");
            Console.Read();
        }
    }
}
