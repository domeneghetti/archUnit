using System;
using System.Collections.Generic;
using archUnitPoc.Domain.Model;

namespace archUnitPoc.Interfaces.Service
{
    public interface IApplicationService
    {
        bool Save(Application model);

        IEnumerable<Application> GetAll();

        void Delete(Guid id);
    }
}
