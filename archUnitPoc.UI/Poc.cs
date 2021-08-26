using archUnitPoc.Domain.Interfaces.Repository;
using archUnitPoc.Domain.Interfaces.Service;
using archUnitPoc.Repository;

namespace archUnitPoc.UI
{
    public class Poc : IPoc
    {
        private readonly IApplicationService _service;
        private readonly IApplicationRepository _repository;

        public Poc(IApplicationService service, IApplicationRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public void Process()
        {
            // First Problem: Concret instance
            // Second Problem: I don't want to UI Layer has access to Repository Layer
            var repository = new ApplicationRepository();
            var applicationData = repository.GetAll();
            
            //var applicationData = _repository.GetAll();

            foreach (var app in applicationData)
            {
                _service.Save(app);
            }
        }
    }
}