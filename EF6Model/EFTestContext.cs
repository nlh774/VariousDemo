using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EF6Model
{
    public class EFTestContext : DbContext
    {
        public DbSet<MessageContract> Message { get; set; }

        public DbSet<AccountContract> Account { get; set; }

        public EFTestContext()
            : base("server=localhost;User Id=sa;password=123456;Persist Security Info=True;database=EFTest;")
        {
            //第一次运行需要建立DB架构，并插入测试数据。之后可删除
            //Database.CreateIfNotExists();
            //this.Account.Add(new AccountContract() {Key = "testAcount"});
            //this.Message.Add(new MessageContract() {Title = "title1", Content = "content1", AccountId = 1});
            //this.Message.Add(new MessageContract() { Title = "title2", Content = "content2", AccountId = 1 });
            //this.SaveChanges();
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
