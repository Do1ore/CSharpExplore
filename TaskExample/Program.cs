Console.WriteLine("Hello,");
PrintCurrentThread();
var task = DoWork1();
Thread.Sleep(2000);
await task;

Console.WriteLine("End");
PrintCurrentThread();

async Task DoWork1()
{
    Thread.Sleep(2000);
    Console.WriteLine("World");
    PrintCurrentThread();
}

async Task DoWork2()
{
    Task.Delay(50);
    Console.WriteLine("World");
    PrintCurrentThread();
}


void PrintCurrentThread()
{
    Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
}
