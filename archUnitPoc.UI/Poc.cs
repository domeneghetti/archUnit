using archUnitPoc.Domain.Interfaces.Service;
using archUnitPoc.Repository;

namespace archUnitPoc.UI
{
    public class Poc : IPoc
    {
        private readonly IApplicationService _service;

        public Poc(IApplicationService service)
        {
            _service = service;
        }

        public void Process()
        {
            // First Problem: Concret instance
            // Second Problem: I don't want to UI Layer has access to Repository Layer
            var repository = new ApplicationRepository();
            var applicationData = repository.GetAll();

            foreach (var app in applicationData)
            {
                _service.Save(app);
            }
        }
    }
}