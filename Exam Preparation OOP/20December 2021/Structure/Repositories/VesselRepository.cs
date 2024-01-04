using Microsoft.Win32.SafeHandles;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> vessels;
        public VesselRepository()
        {
            this.vessels=new HashSet<IVessel>();    
        }
        public IReadOnlyCollection<IVessel> Models =>(IReadOnlyCollection<IVessel>)this.vessels;    

        public void Add(IVessel model)
        {
            vessels.Add( model);
        }

        public IVessel FindByName(string name) 
            => this.vessels.FirstOrDefault(v => v.Name == name);
       

        public bool Remove(IVessel model) 
            => this.vessels.Remove(model);
        
    }
}
