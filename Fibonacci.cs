using System.Diagnostics;

///<summary>
/// Base class for Fibonacci Iterative, Recursive, Memory and Logarithmic  
/// </summary>
public class Fibonacci {
    ///<summary> 
    ///Upper limit of the fibonacci to be found with GetFibonacci 
    ///</summary>
    ///<remarks>
    ///0 default value
    ///</remarks>
    public int Number {get; set;} = 0;
    ///<summary> Time in which the fibonacci is found </summary>
     ///<remarks>Float MinValue default value</remarks>
    public float Time {get; set;} = float.MinValue;

    /// <summary> Contructor for define Number property </summary>
    /// <param name="number">upper limit of fibonacci to find</param>
    public Fibonacci(int number) {
        Number = number;
    }
    
    ///<summary> Default constructor </summary>
    public Fibonacci() { }
}

///<summary>
/// The Fibonacci child class uses a loop to find the fibonacci.
/// </summary>
public class IterativeFibonacci : Fibonacci {
    /// <summary>Contructor for define Number property </summary>
    /// <remarks>Using Fibonacci Class contructor</remarks>
    /// <param name="number">upper limit of fibonacci to find</param>
    public IterativeFibonacci(int number) : base(number) { }

    ///<summary> Default constructor </summary>
    /// <remarks>Using Fibonacci Class contructor</remarks>
    public IterativeFibonacci() : base() { }
    
    /// <summary>Get fibonacci of Number Property using FOR</summary>
    /// <remarks>The Time property is equal to the delay time.</remarks>
    /// <returns> Fibonacci of Number </returns>
    public Int64 GetFibonacci() {
        //creating a stopwatch
        var time = new Stopwatch();
        //starting the count
        time.Start();
        Int64 a = 0, b = 1, c;
        if( Number == 0) return a;
        for(var i = 2; i <= Number; i++) {
            c = a + b;
            a = b;
            b = c;
        }
        //stopping the count
        time.Stop();
        //setting the value of Time to the time obtained from time,
        //adding 0.0000000000000001 so that a value equal to 0 is not obtained.
        //converting to float to avoid data loss and to have more precision
        Time = (float)(time.Elapsed.TotalSeconds + 0.0000000000000001);
        return b;
    }
}

///<summary>
/// The Fibonacci child class, uses a recursive loop to find the fibonacci
/// </summary>
public class RecursiveFibonacci : Fibonacci {

    /// <summary>Contructor for define Number property </summary>
    /// <remarks>Using Fibonacci Class contructor</remarks>
    /// <param name="number">upper limit of fibonacci to find</param>
    public RecursiveFibonacci(int number) : base(number) { }
    ///<summary> Default constructor </summary>
    ///<remarks>Using Fibonacci Class contructor</remarks>
    public RecursiveFibonacci() : base() { }
    
    /// <summary>Get fibonacci of Number Property using recusivity</summary>
    /// <remarks>The Time property is equal to the delay time, use other Method</remarks>
    /// <returns> Fibonacci of Number </returns>
    public Int64 GetFibonacci() {
        //creating a stopwatch
        var time = new Stopwatch();
        //starting the count
        time.Start();
        var getFibonacci = GetFibonacci(Number);
        //stopping the count
        time.Stop();
        //setting the value of Time to the time obtained from time,
        //adding 0.0000000000000001 so that a value equal to 0 is not obtained.
        //converting to float to avoid data loss and to have more precision
        Time = (float)(time.Elapsed.TotalSeconds + 0.0000000000000001);
        return getFibonacci.Last();
    }
    
    /// <summary>Get fibonacci of Number Property using recusivity</summary>
    /// <param name="number">number of fibonacci to find</param>
    /// <returns> Fibonacci of Number </returns>    
    Int64[] GetFibonacci(Int64 number) {
        if(number < 1) return new Int64[1] {0}; 
        if(number < 2) return new Int64[2] {0,1}; 

        var fibonacciPrev = GetFibonacci(number - 1);
        var fibonacci = fibonacciPrev.Concat(new Int64[]{fibonacciPrev[fibonacciPrev.Length - 2] + fibonacciPrev[fibonacciPrev.Length - 1]});    
        return fibonacci.ToArray();
    }

    /// <summary>Get fibonacci of Number Property using recusivity</summary>
    /// <param name="number">number of fibonacci to find</param>
    /// <returns> Fibonacci of Number </returns>    
    Int64 GetFibonacci2(Int64 number) {
        if(number < 1) return 0; 
        if(number < 2) return 1; 
        return GetFibonacci2(number-1) + GetFibonacci2(number-2);
    }

    /// <summary>Get fibonacci of Number Property using recusivity</summary>
    /// <param name="number">number of fibonacci to find</param>
    /// <returns> Fibonacci of Number </returns>    
    Int64 GetFibonacci3(Int64 number) { 
        return number < 2 ? number : GetFibonacci3(number-1) + GetFibonacci3(number-2);
    }

}

///<summary>
/// The Fibonacci child class uses a Dictionary as memory to find the 
///fibonacci using the Dictionary to consume less time and resources.
/// </summary>
public class MemoryFibonacci : Fibonacci {

    /// <summary> Data structure for storing the fibonacci already found </summary>
    Dictionary<int,Int64> Memory {get; set;} = new Dictionary<int, Int64>();

    /// <summary>Contructor for define Number property </summary>
    /// <remarks>Using Fibonacci Class contructor</remarks>
    /// <param name="number">upper limit of fibonacci to find</param>
    public MemoryFibonacci(int number) : base(number) { }
    ///<summary> Default constructor </summary>
    /// <remarks>Using Fibonacci Class contructor</remarks>
    public MemoryFibonacci() : base() { }

    /// <summary> Remove a item or element of Dictionary </summary>
    /// <param name="key"> Key to find the element to remove </param>
    public void Pop(int key) {
        //removing fibonacci of number(key)
        Memory.Remove(key);
    }
    
    /// <summary>Get fibonacci of Number Property using memory (Memory Property)</summary>
    /// <remarks>
    ///The Time property is equal to the delay time, use Memory(Dicctionary)
    /// for save data found. Use other method.
    ///</remarks>
    /// <returns> Fibonacci of Number </returns>
    public Int64 GetFibonacci() {
        //creating a stopwatch
        var time = new Stopwatch();
        //starting the count
        time.Start();
        var getFibonacci = GetFibonacci(Number);
        //stopping the count
        time.Stop();
        //setting the value of Time to the time obtained from time,
        //adding 0.0000000000000001 so that a value equal to 0 is not obtained.
        //converting to float to avoid data loss and to have more precision
        Time = (float)(time.Elapsed.TotalSeconds + 0.0000000000000001);
        return getFibonacci;
    }
    
    /// <summary>Get fibonacci of Number Property using memory (Memory Property)</summary>
    /// <remarks>
    ///The Time property is equal to the delay time, use Memory(Dicctionary)
    /// for save data found. Use other method.
    ///</remarks>
    /// <param name="number">number of fibonacci to find</param>
    /// <returns> Fibonacci of Number </returns>
    Int64 GetFibonacci(int number) { 
        if(number < 1) return 0; 
        if(number < 3) return 1; 
        //using recursivity and memory for to find fibonacci
        return Memory.ContainsKey(number) ? Memory[number] : Memory[number] = GetFibonacci(number - 1) + GetFibonacci(number - 2);
    }
}

///<summary>
/// The Fibonacci child class uses matrix multiplication to find the fibonacci.
/// </summary>
public class LogarithmicFibonacci : Fibonacci {
    /// <summary>Contructor for define Number property </summary>
    /// <remarks>Using Fibonacci Class contructor</remarks>
    /// <param name="number">upper limit of fibonacci to find</param>
    public LogarithmicFibonacci(int number) : base(number) { }
    ///<summary> Default constructor </summary>
    /// <remarks>Using Fibonacci Class contructor</remarks>
    public LogarithmicFibonacci() : base() { }
    
    /// <summary>Get fibonacci of Number Property using memory (Memory Property)</summary>
    /// <remarks>The Time property is equal to the delay time, use Memory(Dicctionary)</remarks>
    /// <returns> Fibonacci of Number </returns>
    public Int64 GetFibonacci() {
        //creating a stopwatch
        var time = new Stopwatch();
        //starting the count
        time.Start();
        if(Number < 1) return 0;
        //defining the characteristic fibonacci matrix
        var matrix = new List<Int64> { 0, 1, 1, 1 };
        var matrixPower = matrix;
        // getting matrix power
        for(var i = 2; i < Number; i++) {
            matrixPower = new List<Int64> { matrixPower[0]*matrix[0] + matrixPower[1]*matrix[2],
                                        matrixPower[0]*matrix[1] + matrixPower[0]*matrix[3],
                                        matrixPower[2]*matrix[0] + matrixPower[3]*matrix[2],
                                        matrixPower[2]*matrix[1] + matrixPower[3]*matrix[3] };
        }
        //getting matrix with fibonacci of number - 1 and fibonacci of number 
        matrix = new List<Int64> { matrixPower[1], matrixPower[3] };
        //stopping the count
        time.Stop();
        //setting the value of Time to the time obtained from time,
        //adding 0.0000000000000001 so that a value equal to 0 is not obtained.
        //converting to float to avoid data loss and to have more precision
        Time = (float)(time.Elapsed.TotalSeconds + 0.0000000000000001);
        return matrix[1];
    }
}