var fibo = new MemoryFibonacci(10);


Console.WriteLine($"{fibo.Number} {fibo.GetFibonacci()} {fibo.Time}");

var fibo2 = new LogarithmicFibonacci(10);

Console.WriteLine($"{fibo2.Number} {fibo2.GetFibonacci()} {fibo2.Time}");
