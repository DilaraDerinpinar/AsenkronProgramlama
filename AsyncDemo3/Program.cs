using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo3
{
    class Program
    {
        static void Main(string[] args)
        {
            //ASYNC-AWAIT ILE ASENKRON METOTLAR
            Console.WriteLine($"Main thread başladı. {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Hello World!");
            Process1Async();
            Process2Async();
            Process1();
            Process2(); //main process1 ve process2 nin thread numaraları 1 dir. asenkron değil senkron çalışırlar.

        }

        static void Process1()
        {
            
            Console.WriteLine($"İşlem 1 başladı. {Thread.CurrentThread.ManagedThreadId}");
        }

        static async Task Process1Async() //dönüş tipleri task olmalı.
        {   //async ise asenkron bir process oldugunu belirtir.
            //await asenktron operasyon kendi içinde sağlıklı bir süreç geçirmesini sağlar yani task.wait() ile aynı işlev görür.
            //bu processteki tüm kodları buraya yazarsın:
            await Task.Run(()=> {
                
                Console.WriteLine($"Asenkron İşlem 1 başladı. {Thread.CurrentThread.ManagedThreadId}");
            });
            
        }

        static void Process2()
        {
            Console.WriteLine($"İşlem 2 başladı. {Thread.CurrentThread.ManagedThreadId}");
        }

        static async Task Process2Async()
        {
            await Task.Run(() => {
                Console.WriteLine($"Async İşlem 2 başladı. {Thread.CurrentThread.ManagedThreadId}");
            });
            
        }
    }
}
