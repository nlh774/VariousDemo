using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EF6Model;

namespace TaskThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 10000;
            //顺序执行，必须执行完该循环才能继续之后的代码
            //for (int index = 0; index < count; index++)
            //{
            //    Do(index);
            //}

            //后台异步执行，不阻塞。将不按序执行，可能index是颠倒、相同的
            //for (int index = 0; index < count; index++)
            //{
            //    ThreadPool.QueueUserWorkItem(t => Do(index));
            //}
            //务必加上Console.ReadLine()来阻塞;否则至程序执行到末尾关闭，线程也不会执行完、可能误操作


            var taskFactory = new TaskFactory();
            var taskThreads = new Task[count];
            for (int index = 0; index < count; index++)
            {
                taskThreads[index] = taskFactory.StartNew(() =>
                {
                    Do(index);
                });
            }
            try
            {
                Task.WaitAll(taskThreads);    //阻塞，等待所有完成
            }
            catch (AggregateException ex)
            {
                foreach (Exception inner in ex.InnerExceptions)
                {
                    string err = string.Format("线程执行出错：异常类型 {0} from {1}", inner.GetType(), inner.Source);
                    //Log(err);
                    Console.WriteLine(inner.Message + "  " + inner.InnerException.Message);
                }
            }

            Console.WriteLine("ok");
            
        }

        private static void Do(int index)
        {
            //Console.WriteLine(index);
            //若DB未建立，则将EFTestContext构造的注释去除，即可建立DB。
            //DB连接字符串，我这里简单处理，写在EFTestContext，应该写在本项目的appSettings中
            using (EFTestContext context = new EFTestContext())
            {
                var msg = new MessageContract() { AccountId = 1, Title = "title" + index, Content = "content" + index };
                context.Message.Add(msg);
                context.SaveChanges();
            }
        }
    }
}
