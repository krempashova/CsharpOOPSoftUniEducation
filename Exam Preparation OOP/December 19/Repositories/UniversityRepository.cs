using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        public UniversityRepository()
        {
            models = new List<IUniversity>();
        }

        private  List<IUniversity> models;

        public IReadOnlyCollection<IUniversity> Models => models;

        public void AddModel(IUniversity model)
        {
            University university = new University(models.Count + 1, model.Name, model.Category, model.Capacity, model.RequiredSubjects.ToList());
            models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return models.FirstOrDefault(n => n.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return models.FirstOrDefault(n => n.Name == name);
        }
    }
}
