using System;
using archUnitPoc.Domain.Service;
using archUnitPoc.Domain.Interfaces.Repository;
using archUnitPoc.Domain.Interfaces.Service;
using archUnitPoc.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace archUnitPoc.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPoc, Poc>()
                .AddScoped<IApplicationService, ApplicationService>()
                .AddScoped<IApplicationRepository, ApplicationRepository>()
                .BuildServiceProvider();


            var poc = serviceProvider.GetService<IPoc>();
            poc.Process();
        }
    }
}
