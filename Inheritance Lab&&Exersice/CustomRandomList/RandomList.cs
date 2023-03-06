using CustomRandomList;

namespace CustomRandomList
{
    public class RandomList: List<string>
    {

       public string RandomString()
        {
            Random random = new Random();
            return this[random.Next(0,Count)];    
        }
       
    }
}
