using System;
using System.Collections.Generic;
using System.Diagnostics;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.Contracts
{
    public class University : IUniversity
    {

        public University(int id, string name, string category, int capacity)
        {
            Id = id;
            Name = name;
            Category = category; 
            Capacity = capacity;
            requiredSubjects = new List<int>();
        }

        public University(int id, string name, string category, int capacity, List<int> requiredSubjectsAsInt) : this(id, name, category, capacity)
        {
            this.requiredSubjectsAsInt = requiredSubjectsAsInt;
        }

        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjectsAsInt;
        private readonly List<int> requiredSubjects;

        

        public int Id
        {
            get { return id; }
           private set { this.id = value; }
        }

       

        public string Name
        {
            get { return name; }
          private   set

            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }



                this.name = value; }
        }

       

        public string Category
        {
            get { return category; }
           private set 
            
            
            { 
                if(value!= "Technical" || value!= "Economical" || value!= "Humanity")
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CategoryNotAllowed,value));
                }
                
                
                
                this.category = value; }
        }

       

        public int Capacity
        {
            get { return capacity; }
             private set 
            { 
                if(value<0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CapacityNegative));
                }
                
                
                capacity = value; }
        }



        public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects;
    }
}
