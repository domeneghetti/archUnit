using System;
using Xunit;
using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;

using static ArchUnitNET.Fluent.ArchRuleDefinition;
using archUnitPoc.Domain.Model;
using archUnitPoc.Domain.Service;
using archUnitPoc.Repository;
using ArchUnitNET.xUnit;
using archUnitPoc.Domain.Interfaces.Repository;

namespace archUnitPoc.Test
{
    public class PocTest
    {
        // Definition class will be tested
        private static readonly Architecture architecture =
            new ArchLoader().LoadAssemblies(
                typeof(Poc).Assembly,
                typeof(Application).Assembly,
                typeof(ApplicationService).Assembly,
                typeof(ApplicationRepository).Assembly)
            .Build();

    
        [Fact]
        public void ValidateDependeceRepositoryLayer()
        {
            IArchRule rule = Classes()
                .That().ResideInAssembly(typeof(ApplicationRepository).Assembly)
                .Should().OnlyDependOn(typeof(IApplicationRepository));
                //.ImplementInterface(typeof(IApplicationRepository))
                //.ResideInAssembly(typeof(ApplicationService).Assembly);

            rule.Check(architecture);
        }

        [Fact]
        public void ValidateRepositoryLayerClassName()
        {
            IArchRule rule = Classes()
                .That().ResideInAssembly(typeof(ApplicationRepository).Assembly)
                .Should().HaveNameContaining("Repository");

            rule.Check(architecture);
        }
    }
}
