using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using EF6Model;

namespace EF6_ConsoleApp
{
    class Program
    {
        private static void Main()
        {
            //若DB未建立，则将EFTestContext构造的注释去除，即可建立DB。
            //DB连接字符串，我这里简单处理，写在EFTestContext，应该写在本项目的appSettings中
            using (EFTestContext context = new EFTestContext())
            {
                var account = context.Account.FirstOrDefault(t => t.AccountId == 1);        //查询账号,延迟加载消息表（Message暂时不查询，需要用到时再自动查询出来）
                var msg = account.Messages.First(); //查询消息
                #region 转换出的sql

                //只查询账号
                //SELECT TOP (1) 
                //[Extent1].[AID] AS [AID], 
                //[Extent1].[aKey] AS [aKey]
                //FROM [dbo].[TCBaseAccount] AS [Extent1]
                //WHERE 1 = [Extent1].[AID]

                //需要用到Message时再自动查询出来
                //exec sp_executesql N'SELECT 
                //[Extent1].[MID] AS [MID], 
                //[Extent1].[MAID] AS [MAID], 
                //[Extent1].[mTitle] AS [mTitle], 
                //[Extent1].[mContent] AS [mContent]
                //FROM [dbo].[TCBaseMessage] AS [Extent1]
                //WHERE [Extent1].[MAID] = @EntityKeyValue1',N'@EntityKeyValue1 bigint',@EntityKeyValue1=1 

                #endregion
                msg.Title = "zzzzz";
                context.SaveChanges();
                #region EF只更新Title字段，还是蛮聪明的

                //exec sp_executesql N'UPDATE [dbo].[TCBaseMessage]
                //SET [mTitle] = @0
                //WHERE ([MID] = @1)
                //',N'@0 nvarchar(256),@1 bigint',@0=N'zzzzz',@1=1

                #endregion


                //var account = context.Account.Include(t => t.Messages).FirstOrDefault(t => t.AccountId == 1);   //查询账号并指定附带查询出该账号所属的消息，立即查询（不延迟加载）
                #region 转换出的sql，虽然丑了点，但是相信sqlserver 会优化的，具体未知。

                //SELECT [Project2].[C1] AS [C1],
                //       [Project2].[AID] AS [AID],
                //       [Project2].[aKey] AS [aKey],
                //       [Project2].[C2] AS [C2],
                //       [Project2].[MID] AS [MID],
                //       [Project2].[MAID] AS [MAID],
                //       [Project2].[mTitle] AS [mTitle],
                //       [Project2].[mContent] AS [mContent]
                //FROM   (
                //           SELECT [Limit1].[AID] AS [AID],
                //                  [Limit1].[aKey] AS [aKey],
                //                  [Limit1].[C1] AS [C1],
                //                  [Extent2].[MID] AS [MID],
                //                  [Extent2].[MAID] AS [MAID],
                //                  [Extent2].[mTitle] AS [mTitle],
                //                  [Extent2].[mContent] AS [mContent],
                //                  CASE 
                //                       WHEN ([Extent2].[MID] IS NULL) THEN CAST(NULL AS INT)
                //                       ELSE 1
                //                  END AS [C2]
                //           FROM   (
                //                      SELECT TOP(1) 
                //                             [Extent1].[AID] AS [AID],
                //                             [Extent1].[aKey] AS [aKey],
                //                             1 AS [C1]
                //                      FROM   [dbo].[TCBaseAccount] AS [Extent1]
                //                      WHERE  1 = [Extent1].[AID]
                //                  ) AS [Limit1]
                //                  LEFT OUTER JOIN [dbo].[TCBaseMessage] AS [Extent2]
                //                       ON  [Limit1].[AID] = [Extent2].[MAID]
                //       ) AS [Project2]
                //ORDER BY
                //       [Project2].[AID] ASC,
                //       [Project2].[C2] ASC 

                #endregion


                //若要性能高，可以自己写sql。sql中的列定义要符合模型的属性名，所以用AS关键字
                //单表，只查账号表
//            string sqlAcc = @"SELECT TOP 1000 [AID] AS [AccountId],[aKey] AS [Key]
//                              FROM [EFTest].[dbo].[TCBaseAccount] WITH(NOLOCK) ";
//            var accounts2 = context.Database.SqlQuery<AccountContract>(sqlAcc).ToList(); //ToList()指定立即查询

                //两表联查，查账号及其归属的消息
//            string sqlAccMsg = @"SELECT ta.AID AS [AccountId],ta.aKey AS [Key],tm.MID AS [MessageId],tm.mTitle AS [Titlle],tm.mContent AS [Content]
//                                 FROM TCBaseAccount ta WITH(NOLOCK) 
//                                 INNER JOIN TCBaseMessage tm  WITH(NOLOCK)
//                                 ON tm.MAID = ta.AID ";
//            var accounts3 = context.Database.SqlQuery<AccountContract>(sqlAccMsg).ToList(); //ToList()指定立即查询

              //若量大，可能慢
              //int effectRows = context.Database.ExecuteSqlCommand("delete from TCBaseMessage");
            }
        }
    }
}
