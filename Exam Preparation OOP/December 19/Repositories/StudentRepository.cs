using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        private readonly List<IStudent> models;

        public IReadOnlyCollection<IStudent> Models => models;

        public void AddModel(IStudent model)
        {
            Student student = new Student(models.Count + 1, model.FirstName, model.LastName);
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return models.FirstOrDefault(n => n.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] fULLNAME = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            return models.FirstOrDefault(n => n.FirstName == fULLNAME[0] && n.LastName == fULLNAME[1]);
        }
    }
}

