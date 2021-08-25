using System;
using System.Collections.Generic;
using archUnitPoc.Domain.Model;

namespace archUnitPoc.Domain.Interfaces.Repository
{
    public interface IApplicationRepository
    {
        bool Save(Application model);

        IEnumerable<Application> GetAll();

        void Delete(Guid id);
    }
}
