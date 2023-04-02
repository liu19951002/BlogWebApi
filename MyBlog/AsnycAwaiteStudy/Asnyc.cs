using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsnycAwaiteStudy
{
    public class Asnyc
    {
        public async  Task Test()
        {
            
            await Task.Run(() =>
            {
                Console.WriteLine("开始新线程1");
                Thread.Sleep(3000);
                Console.WriteLine("新线程1休息结束");
            });
            await Task.Run(() =>
            {
                Console.WriteLine("开始新线程2");
                Thread.Sleep(3000);
                Console.WriteLine("新线程2休息结束");

            });
            await Task.Run(() =>
            {
                Console.WriteLine("开始新线程3");
                Thread.Sleep(3000);
                Console.WriteLine("新线程3休息结束");

            });
            await Task.Run(() =>
            {
                Console.WriteLine("开始新线程4");
                Thread.Sleep(3000);

            });
            await Task.Run(() =>
            {
                Console.WriteLine("开始新线程5");
                Thread.Sleep(3000);

            });
            await Task.Run(() =>
            {
                Console.WriteLine("开始新线程6");
                Thread.Sleep(3000);

            });
        }
    }
}
