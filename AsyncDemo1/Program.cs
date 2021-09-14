using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.YÖNTEM

            //Task task1 = new Task(Process1);
            //task1.Start();

            //2.YÖNTEM
            //Task task1 = Task.Factory.StartNew(Process1);

            //3.YÖNTEM
            //Task task1 = Task.Run(Process1); //hızlı çalıştırır.

            //4.YÖNTEM çalışma esnasında bir metod oluşturulabilir
            //Task task1 = Task.Run(()=> { //task1 diğerleri ile asenkron çalışır
            //    Process1();
            //    Process2();
            //    //process1 ve 2 sıralı bir şekilde çalışacaktır.asenkron şekilde değil
            //});

            Task task1 = Task.Run(Process1);

            task1.Wait(); //task1 in çalışmama olasılığını ortadan kaldırıp ikinci işleme geçer. çünkü ikinci işlemin birinci işlemin çıktısına ihtiyaç duydugu senaryolar olabilir.
            Process2();
            Console.ReadKey(); //herhangi bir tuşa basınca sonlansın console.

        }
        static void Process1()
        {
            Console.WriteLine("1.işleme başladın");
            Console.WriteLine($"Thread no:  { Thread.CurrentThread.ManagedThreadId}");
        }

        static void Process2()
        {
            Console.WriteLine("2.işleme başladın");
            Console.WriteLine($"Thread no:  { Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
