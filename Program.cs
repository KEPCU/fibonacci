using System.Text;

///<summary>
/// Class for use the Class Fibonacci methods 
/// </summary>
public class Program {  

    /// <summary>
    /// Get fibonacci in a range from 0 to number, generate a csv file 
    /// with the times of each type of fibonacci for each number between 0 to number. 
    /// </summary>
    /// <param name="number">Upper limit of fibonacci to find</param>
    /// <returns>Does not return anything, generates a csv file </returns>
    static void GetFibonacci(int number) {
        //setting a date for the file name
        var date = DateTime.Now.ToLocalTime();
        //ceating a variables for get the fibonacci value
        var iterativeFibonacci = new IterativeFibonacci();
        var recursiveFibonacci = new RecursiveFibonacci();
        var memoryFibonacci = new MemoryFibonacci();
        var logarithmicFibonacci = new LogarithmicFibonacci();

        //creating a StringBuilder for create a csv file
        StringBuilder csvContent = new StringBuilder();
        //defining the names and numbers of the columns of the csv file
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
            //adding the time per funtion
            csvContent.AppendLine($"{i},{iterativeFibonacci.Time},{recursiveFibonacci.Time},{memoryFibonacci.Time},{logarithmicFibonacci.Time}");
        }
        //creating the csv file, the name varies by date
        File.AppendAllText($"fibonacci{date.ToString("yyyy-MM-ddTHH-mm")}.csv",csvContent.ToString());
    }
    
    /// <summary>
    /// Get average fibonacci in a range from 0 to number, generate a csv file 
    /// with the times of each type of fibonacci for each number between 0 to number
    /// </summary>
    /// <remarks>Are 20 repetitions to obtain a time average</remarks>
    /// <param name="number">Upper limit of fibonacci to find</param>
    /// <param name="repetitions">The number of test iterations for testing</param>
    /// <returns>Does not return anything, generates a csv file </returns>
    static void GetFibonacciAverage(int number, int repetitions) {
        //setting a date for the file name
        var date = DateTime.Now.ToLocalTime();

        //ceating a variables for get the fibonacci value
        var iterativeFibonacci = new IterativeFibonacci();
        var recursiveFibonacci = new RecursiveFibonacci();
        var memoryFibonacci = new MemoryFibonacci();
        var logarithmicFibonacci = new LogarithmicFibonacci();

        //creating a StringBuilder for create a csv file
        StringBuilder csvContent = new StringBuilder();
        //defining the names and numbers of the columns of the csv file
        csvContent.AppendLine("Number,Iterative,Rcursive,Memory,Logarithmic");

        var myFibo = new Dictionary<int,float[]>();

        for(int i = 0; i < number + 1; i++) {
            //array for get the average 
            var averageTime = new float[4];
            for(int j = 1; j < repetitions + 1; j++) {
                /*
                in all Fibonacci calculations is added the condition that the time is not 
                greater than the sum of the obtained times
                */
                iterativeFibonacci = new IterativeFibonacci(i);
                iterativeFibonacci.GetFibonacci();
                averageTime[0] += j > 1 && (iterativeFibonacci.Time) > ((float)1.5 * averageTime[0]) ? averageTime[0] / (float)j : iterativeFibonacci.Time;
                
                recursiveFibonacci = new RecursiveFibonacci(i);
                recursiveFibonacci.GetFibonacci();
                averageTime[1] += j > 1 && (recursiveFibonacci.Time) > ((float)1.5 * averageTime[1]) ? averageTime[1] / (float)j : recursiveFibonacci.Time;
                
                memoryFibonacci = new MemoryFibonacci(i);
                memoryFibonacci.GetFibonacci();
                //removing the fibonacci value to obtain the appropriate average
                //if and only if it is not the last iteration
                if(j + 1 != repetitions) memoryFibonacci.Pop(i);
                averageTime[2] += j > 1 && (memoryFibonacci.Time) > ((float)1.5 * averageTime[2]) ? averageTime[2] / (float)j : memoryFibonacci.Time;

                logarithmicFibonacci = new LogarithmicFibonacci(i);
                logarithmicFibonacci.GetFibonacci();
                averageTime[3] += j > 1 && (logarithmicFibonacci.Time) > ((float)1.5 * averageTime[3]) ? averageTime[3] / (float)j : logarithmicFibonacci.Time;     
            }
            //getting the average delay per method, in case value equals to negative infinite then value equals to (float)0.0000000000000001
            averageTime[0] = (averageTime[0] / (float)repetitions) == float.NegativeInfinity ? (float)0.0000000000000001 : (averageTime[0] / (float)repetitions);
            averageTime[1] = (averageTime[1] / (float)repetitions) == float.NegativeInfinity ? (float)0.0000000000000001 : (averageTime[1] / (float)repetitions);
            averageTime[2] = (averageTime[2] / (float)repetitions) == float.NegativeInfinity ? (float)0.0000000000000001 : (averageTime[2] / (float)repetitions);
            averageTime[3] = (averageTime[3] / (float)repetitions) == float.NegativeInfinity ? (float)0.0000000000000001 : (averageTime[3] / (float)repetitions);
            myFibo.Add(i, averageTime);
        }

        //regulating time values obtained
        for (int i = 0; i < number + 1; i++) {
            //iteration by Fibonacci type
            for (int j = 0; j < 4; j++) {
                if (i > 0 && i + 1 < number) {
                    //if the Fibonacci time of N is less than the Fibonacci time of N-1
                    if (myFibo[i-1][j] > myFibo[i][j]) {
                        myFibo[i][j] = (float)((myFibo[i-1][j] + myFibo[i+1][j]) / (float)2.0);
                    }
                    //if the Fibonacci time of N+1 is less than the Fibonacci time of N
                    if (myFibo[i+1][j] < myFibo[i][j]) {
                        myFibo[i][j] = (float)((myFibo[i-1][j] + myFibo[i+1][j]) / (float)2.0);
                    }
                }
                //if the Fibonacci time of 0 is less than the Fibonacci time of 1
                else if (i == 0) {
                    if (myFibo[i+1][j] < myFibo[i][j]) {
                        myFibo[i][j] = (float)((myFibo[i+1][j]) / (float)2.0);
                    }
                }
                //Nothing
                else { }
            }
            //adding the time per funtion
            csvContent.AppendLine($"{i},{myFibo[i][0]},{myFibo[i][1]},{myFibo[i][2]},{myFibo[i][3]}"); 
        }
        //creating the csv file, the name varies by date
        File.AppendAllText($"FibonacciAverage{date.ToString("yyyy-MM-ddTHH-mm")}.csv",csvContent.ToString());
    }

    ///<summary>
    /// Function or method for testing and using fibonacci functions and creating a csv file
    /// </summary>
    public static void Main (string[] args) {
        //get the number 
        Console.WriteLine("number: ");
        //if input value equals to "" or empty, string value equals to 0
        int number = Int32.Parse(Console.ReadLine() ?? "0");

        //get the repetitions 
        Console.WriteLine("repetitions: ");
        //if input value equals to "" or empty, string value equals to 20
        int repetitions = Int32.Parse(Console.ReadLine() ?? "5");
        GetFibonacciAverage(number,repetitions);
    }
  
}