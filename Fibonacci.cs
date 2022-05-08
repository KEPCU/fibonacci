using System.Diagnostics;

///<summary>
/// Base class for Fibonacci Iterative, Recursive, Memory and Logarithmic  
/// </summary>
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

public class RecursiveFibonacci : Fibonacci {
  public RecursiveFibonacci(int number) : base(number) { }
  public RecursiveFibonacci() : base() { }

  public int GetFibonacci() {
    var time = new Stopwatch();
    time.Start();
    var getFibonacci = GetFibonacci(Number);
    time.Stop();
     Time = (float)(time.Elapsed.TotalSeconds + 0.00000000001);
    return getFibonacci;
  }

  int GetFibonacci(int number) {
    if (number < 2) return number;
    return GetFibonacci(number - 1) + GetFibonacci(number - 2);
  }
}

public class MemoryFibonacci : Fibonacci {
  Dictionary<int,int> Memory {get; set;} = new Dictionary<int, int>();
  public MemoryFibonacci(int number) : base(number) { }
  public MemoryFibonacci() : base() { }

  public void Pop(int key) {
    Memory.Remove(key);
  }

  public int GetFibonacci() {
    var time = new Stopwatch();
    time.Start();
    var getFibonacci = GetFibonacci(Number);
    time.Stop();
    Time = (float)(time.Elapsed.TotalSeconds + 0.00000000001);
    return getFibonacci;
  }
  
  int GetFibonacci(int number) { 
    if(number < 1) return 0; 
    if(number < 3) return 1; 
    return Memory.ContainsKey(number) ? Memory[number] : Memory[number] = GetFibonacci(number - 1) + GetFibonacci(number - 2);
  }
}

public class LogarithmicFibonacci : Fibonacci {
  public LogarithmicFibonacci(int number) : base(number) { }
  public LogarithmicFibonacci() : base() { }

  public int GetFibonacci() {
    var time = new Stopwatch();
    time.Start();
    if(Number < 1) return 0;
    var matrix = new List<int> { 0, 1, 1, 1 };
    var matrixPower = matrix;
    for(var i = 2; i < Number; i++) {
        matrixPower = new List<int> { matrixPower[0]*matrix[0] + matrixPower[1]*matrix[2],
                                      matrixPower[0]*matrix[1] + matrixPower[0]*matrix[3],
                                      matrixPower[2]*matrix[0] + matrixPower[3]*matrix[2],
                                      matrixPower[2]*matrix[1] + matrixPower[3]*matrix[3] };
    }
    matrix = new List<int> { matrixPower[1], matrixPower[3] };
    time.Stop();
    Time = (float)(time.Elapsed.TotalSeconds + 0.00000000001);
    return matrix[1];
  }
}



