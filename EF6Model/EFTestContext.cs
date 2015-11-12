using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EF6Model
{
    public class EFTestContext : DbContext
    {
        public DbSet<MessageContract> Message { get; set; }

        public DbSet<AccountContract> Account { get; set; }

        public DbSet<UserContract> User { get; set; }

        public EFTestContext()
            : base(ConfigurationManager.ConnectionStrings["EF6Test"].ConnectionString)
        {
            //第一次运行需要建立DB架构，并插入测试数据。之后可删除
            //Database.Delete();
            //if (!Database.Exists())
            //{
            //    Database.Create();
            //    //this.Account.Add(new AccountContract() { Key = "testAcount" });
            //    //this.Message.Add(new MessageContract() { Title = "title1", Content = "content1", AccountId = 1 });
            //    //this.Message.Add(new MessageContract() { Title = "title2", Content = "content2", AccountId = 1 });
            //    this.User.Add(new UserContract
            //    {
            //        Name = "nlh",
            //        CardId = "11111",
            //        Password = "222",
            //        CreatedOn = DateTime.Now
            //    });
            //    this.SaveChanges();
            //}
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //账号-消息，一对多关系
            modelBuilder.Entity<AccountContract>()
                .HasMany(t => t.Messages).WithRequired(t=>t.Account);
        }
    }
}
