namespace PersonsInfo
{
    public class Person
    {

		private string firstName;

		public Person(string firstName, string lastName,int age,decimal salary)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Salary = salary;
		}
		public string FirstName
		{
			get { return  firstName; }
			 private set {  firstName = value; }
		}
		private string lastName;

		public string LastName
		{
			get { return lastName; }
			 private set { lastName = value; }
		}
		private int age;

		public int Age
		{
			get { return age; }
			private set { age = value; }
		}
		private decimal salary;

		public decimal Salary
		{
			get { return salary; }
			 private set { salary = value; }
		}

		public void IncreaseSalary(decimal percentage)
		{
			decimal increase = Salary * percentage / 100;
			if (age < 30)
			{
				increase /= 2;
				
			}
            Salary += increase;
        }


        public override string ToString()
        {
			return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

    }
}
