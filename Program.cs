using System.Text;

/// <summary>
/// Get fibonacci in a range from 0 to number, generate a csv file 
/// with the times of each type of fibonacci for each number between 0 to number. 
/// </summary>
/// <param name="number">upper limit of fibonacci to find</param>
/// <returns>Does not return anything, generates a csv file </returns>
void GetFibonacci(int number) {
    var date = DateTime.Now.ToLocalTime();

    var iterativeFibonacci = new IterativeFibonacci();
    var recursiveFibonacci = new RecursiveFibonacci();
    var memoryFibonacci = new MemoryFibonacci();
    var logarithmicFibonacci = new LogarithmicFibonacci();

    StringBuilder csvContent = new StringBuilder();
    csvContent.AppendLine("Number,Iterative,Rcursive,Memory,Logarithmic");

    for(int i = 0; i < number; i++) {
      iterativeFibonacci = new IterativeFibonacci(i);
      iterativeFibonacci.GetFibonacci();
      
      recursiveFibonacci = new RecursiveFibonacci(i);
      recursiveFibonacci.GetFibonacci();
      
      memoryFibonacci = new MemoryFibonacci(i);
      memoryFibonacci.GetFibonacci();

      logarithmicFibonacci = new LogarithmicFibonacci(i);
      logarithmicFibonacci.GetFibonacci();

      csvContent.AppendLine($"{i},{iterativeFibonacci.Time},{recursiveFibonacci.Time},{memoryFibonacci.Time},{logarithmicFibonacci.Time}");
    }

    File.AppendAllText($"fibonacci{date.ToString("yyyy-MM-ddTHH-mm")}.csv",csvContent.ToString());
  }

/// <summary>
/// Get average fibonacci in a range from 0 to number, generate a csv file 
/// with the times of each type of fibonacci for each number between 0 to number
/// </summary>
/// <remarks>Are 20 repetitions to obtain a time average</remarks>
/// <param name="number">upper limit of fibonacci to find</param>
/// <returns>Does not return anything, generates a csv file </returns>
void GetFibonacciAverage(int number) {
    var date = DateTime.Now.ToLocalTime();
    var iterativeFibonacci = new IterativeFibonacci();
    var recursiveFibonacci = new RecursiveFibonacci();
    var memoryFibonacci = new MemoryFibonacci();
    var logarithmicFibonacci = new LogarithmicFibonacci();

    var myFibo = new List<Fibonacci>();

    StringBuilder csvContent = new StringBuilder();
    csvContent.AppendLine("Number,Iterative,Rcursive,Memory,Logarithmic");

    int repetitions = 20;
    for(int i = 0; i < number + 1; i++) {
      var averageTime = new float[4];
      for(int j = 0; j < repetitions; j++) {
        iterativeFibonacci = new IterativeFibonacci(i);
        iterativeFibonacci.GetFibonacci();
        averageTime[0] += iterativeFibonacci.Time;
        
        recursiveFibonacci = new RecursiveFibonacci(i);
        recursiveFibonacci.GetFibonacci();
        averageTime[1] += recursiveFibonacci.Time;
        
        memoryFibonacci = new MemoryFibonacci(i);
        memoryFibonacci.GetFibonacci();
        if(j + 1 != repetitions) memoryFibonacci.Pop(i);
        averageTime[2] += memoryFibonacci.Time;

        logarithmicFibonacci = new LogarithmicFibonacci(i);
        logarithmicFibonacci.GetFibonacci();
        averageTime[3] += logarithmicFibonacci.Time;        
      }
      averageTime[0] /= (float)repetitions;
      averageTime[1] /= (float)repetitions;
      averageTime[2] /= (float)repetitions;
      averageTime[3] /= (float)repetitions;
      csvContent.AppendLine($"{i},{averageTime[0]},{averageTime[1]},{averageTime[2]},{averageTime[3]}"); 
    }
    File.AppendAllText($"FibonacciAverage{date.ToString("yyyy-MM-ddTHH-mm")}.csv",csvContent.ToString());
  }

//get a number 
Console.WriteLine("number: ");
// if input value equals to "" or empty, string value equals to 0
int number = Int32.Parse(Console.ReadLine() ?? "0");
GetFibonacciAverage(number);
