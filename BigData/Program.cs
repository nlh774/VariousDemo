using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EF6Model.Service;
using EF6Model;

namespace BigData
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            //userService.BulkInsert();

            for (int i = 0; i < 3; i++)
            {
                userService.InsertUseByEF(i);
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                userService.InsertUseBySqlHelper(i);
            }

            Thread.Sleep(10000);
            Console.WriteLine();

            Console.WriteLine("ok");
            Console.Read();
        }
    }
}
