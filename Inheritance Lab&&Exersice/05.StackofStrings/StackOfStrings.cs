using CustomStack;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {

        public bool IsEmpty()
        {
            return Count == 0;
        }
         public Stack<string> AddRange(IEnumerable<string>collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
