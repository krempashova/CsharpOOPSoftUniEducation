namespace _01.ClassBoxData
{
    public class StartUp

    {

        public static void Main()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Box box = new Box(length, width, height);
                Console.WriteLine(box);
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
            


        }
    }
}