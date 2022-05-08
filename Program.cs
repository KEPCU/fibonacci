using System.Text;

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

Console.WriteLine("number: ");
int number = Int32.Parse(Console.ReadLine() ?? "0");
GetFibonacci(number);
