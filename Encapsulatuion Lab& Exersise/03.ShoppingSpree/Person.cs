using System.Collections.Concurrent;
using System.Diagnostics.Metrics;
using System.Threading;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
            
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;

            }
        }
        public decimal Money
        {
            get => money;
            private set

            {

                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            string bagString =products.Any()
                 ? string.Join(", ", products)
                 : "Nothing bought ";
            return $"{Name} - {bagString}";
        }
        public string AddProduct(Product product)
        {
            if(Money<product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }
            else
            {

                products.Add(product);
                Money -= product.Cost;
                return $"{Name} bought {product.Name}";
            }
        }

    }
}
