namespace UniversityCompetition.Models
{
    using Contracts;
    using System;
    using UniversityCompetition.Utilities.Messages;

    public abstract class Subject : ISubject
    {
        public Subject(int id, string name, double rate)
        {
            Id = id;
            Name = name;
            Rate = rate;
        }
        private int id;

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set 
            { 
               if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                
                
                
                name = value; }
        }


        private double rate;

        public double Rate
        {
            get { return rate; }
            private set { rate = value; }
        }


        
    }
}
