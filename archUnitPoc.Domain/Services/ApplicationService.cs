using System;
using System.Collections.Generic;
using archUnitPoc.Domain.Model;
using archUnitPoc.Domain.Interfaces.Repository;
using archUnitPoc.Domain.Interfaces.Service;

namespace archUnitPoc.Domain.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;

        
        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Application> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Save(Application model)
        {
            return _repository.Save(model);
        }
    }
}
