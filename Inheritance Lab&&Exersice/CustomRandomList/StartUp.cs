using CustomRandomList;

namespace CustomRandomList
{
    public class StartUp
    {

        public static void Main(string[]args)
        {
            RandomList list =new RandomList();
            list.Add("NEW");
            list.Add("two");
            list.Add("5");
            list.Add("3");

            Console.WriteLine(list.RandomString()) ;
        }

       
    }
}
