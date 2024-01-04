using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class MyRangeAttribute: MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            int MinValue = minValue;
            int MaxValue = maxValue;    
        }

        public override bool IsValid(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
