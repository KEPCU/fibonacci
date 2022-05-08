using System.Diagnostics;

public class Fibonacci {
  public int Number {get; set;} = 0;
  public float Time {get; set;} = float.MinValue;
  public Fibonacci(int number) {
    Number = number;
  }

  public Fibonacci() { }
}

public class IterativeFibonacci : Fibonacci {
  public IterativeFibonacci(int number) : base(number) { }
  public IterativeFibonacci() : base() { }

  public int GetFibonacci() {
    var time = new Stopwatch();
    time.Start();
    int a = 0, b = 1, c;
    if( Number == 0) return a;
    for(var i = 2; i <= Number; i++) {
        c = a + b;
        a = b;
        b = c;
     }
     time.Stop();
     Time = (float)(time.Elapsed.TotalSeconds + 0.00000000001);
     return b;
  }
}