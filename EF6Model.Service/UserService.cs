using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EF6Model.Service
{
    public class UserService
    {
        public void Find()
        {
            DateTime dt = DateTime.Parse("2015-11-12 20:40");
            using (EFTestContext context = new EFTestContext())
            {
                Console.WriteLine(context.User.FirstOrDefault(t => t.CreatedOn > dt).AccountId);
            }
        }


        public void BulkInsert()
        {
            using (EFTestContext context = new EFTestContext())
            {
                Stopwatch st = new Stopwatch();
                int count = 10000000;

                //context.User.Add(new UserContract
                //{
                //    Name = "nlh",
                //    CardId = "11111",
                //    Password = "222",
                //    CreatedOn = DateTime.Now
                //});
                //context.SaveChanges();


                st.Start();
                for (int i = 0; i < count; i++)
                {
                    context.User.Add(new UserContract
                    {
                        Name = "nlh",
                        CardId = "11111",
                        Password = "222",
                        CreatedOn = DateTime.Now
                    });
                }
                context.BulkSaveChanges();
                st.Stop();
                Console.WriteLine(st.ElapsedMilliseconds);

                //st.Restart();
                //for (int i = 0; i < count; i++)
                //{
                //    context.User.Add(new UserContract
                //    {
                //        Name = "nlh",
                //        CardId = "11111",
                //        Password = "222",
                //        CreatedOn = DateTime.Now
                //    });
                //}
                //context.SaveChanges();
                //st.Stop();
                //Console.WriteLine(st.ElapsedMilliseconds);
            }
        }
    }
}
