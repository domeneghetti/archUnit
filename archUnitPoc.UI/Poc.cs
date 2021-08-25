using archUnitPoc.Domain.Interfaces.Service;
using archUnitPoc.Repository;

public class Poc : IPoc
 {
     private readonly IApplicationService _service;

     public Poc(IApplicationService service)
     {
         _service = service;
     }

     public void Process() 
     {
        var repository = new ApplicationRepository();
        var applicationData = repository.GetAll();

        
        foreach(var app in applicationData)
        {
            _service.Save(app);
        }
     }
 }