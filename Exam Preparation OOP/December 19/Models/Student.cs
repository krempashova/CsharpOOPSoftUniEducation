using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {

        public Student(int id, string firstName,string lastName)

        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();

        }
        private int id;

        public int Id
        {
            get { return id; }
           private  set { id = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
          private   set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                
                
                
                firstName = value; }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
           private  set 
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }



                lastName = value; }
        }
        private readonly List<int> coveredExams;
        private IUniversity university;


        public IReadOnlyCollection<int> CoveredExams => coveredExams.AsReadOnly();

        public IUniversity University =>  university;


        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.university = university;
        }
    }
}
