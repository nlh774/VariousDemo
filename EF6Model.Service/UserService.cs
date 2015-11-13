using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using CommTools;

namespace EF6Model.Service
{
    public class UserService
    {
        public int InsertUseByEF(int i)
        {
            using (EFTestContext context = new EFTestContext())
            {
                var user = new UserContract
                {
                    Name = "InsertUseByEF" + i,
                    CardId = "11111",
                    Password = "222",
                    CreatedOn = DateTime.Now
                };
                context.User.Add(user);
                return context.SaveChanges();
            }
        }

        public int InsertUseBySqlHelper(int i)
        {
            string conn = ConfigurationManager.ConnectionStrings["EF6Test"].ConnectionString;
            string sqlInsert = string.Format(@"
                                INSERT INTO TCBaseUser
                                (
	                                Name,
	                                CardId,
	                                [Password],
	                                CreatedOn
                                )
                                VALUES
                                (
	                                'InsertUseBySqlHelper{0}',
	                                '11111',
	                                '222',
	                                '2015-11-13 11:00:00'
                                )", i);
            return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sqlInsert);
        }

        public void BulkInsert()
        {
            const int perInsertCount = 100000;
            using (EFTestContext context = new EFTestContext())
            {
                for (int i = 0; i < 100; i++)
                {
                    List<UserContract> users = new List<UserContract>(perInsertCount + 1);
                    for (int j = 0; j < perInsertCount; j++)
                    {
                        var user = new UserContract
                        {
                            Name = "nlh" + j + 1,
                            CardId = "11111",
                            Password = "222",
                            CreatedOn = DateTime.Now
                        };
                        //context.User.Add(user);   //直接插入上下文，下面调用SaveChanges(),BulkSaveChanges()更新
                        users.Add(user);
                    }
                    //context.SaveChanges();
                    context.BulkInsert(users);  //context.BulkSaveChanges();  没有context.BulkInsert(users);快
                    
                }
            }
        }
    }
}
