using System.ComponentModel;

namespace Operations
{

    public class StartUp
    { 
    
    static void Main(string[] args)
        {
            MathOperations operations=new MathOperations();
            Console.WriteLine(operations.Add(3,2.4,1));
        }
    
    
    }



}

