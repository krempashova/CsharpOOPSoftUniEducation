namespace _03.ShoppingSpree
{
    public class Product
    {

		private string name;
		public Product(string name, decimal cost)
		{
			Name = name;
			Cost=cost;
		}

		public string Name
		{
			get =>name; 
			private set 
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
					                }
                name = value;

            }
		}
		private decimal cost;

		public decimal Cost
		{
			get => cost;
			private set 
			
			{

                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
				cost = value;
            }
		}
        public override string ToString()
        {
			return Name;
        }

    }
}
