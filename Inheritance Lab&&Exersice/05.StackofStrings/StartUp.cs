using CustomStack;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[]args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new List<string>(){"edno", "dve", "tri", "chetiri"});
            Console.WriteLine(stack.IsEmpty());


        }

       
       

    }
}
