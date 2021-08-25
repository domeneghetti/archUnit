using System;
using System.Collections.Generic;
using archUnitPoc.Domain.Model;
using archUnitPoc.Domain.Interfaces.Repository;

namespace archUnitPoc.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Application> GetAll()
        {
            return new List<Application>() 
            {
                new Application() { Id= 1, Name = "Poc 1"  },
                new Application() { Id= 2, Name = "Poc 2"  },
                new Application() { Id= 3, Name = "Poc 3"  },
            };
        }

        public bool Save(Application model)
        {
            Console.WriteLine($"Save current Model: {model.Name}");
            return true;
        }
    }
}
