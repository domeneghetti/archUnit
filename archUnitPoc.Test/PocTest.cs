using Xunit;
using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;
using archUnitPoc.Repository;
using ArchUnitNET.xUnit;
using archUnitPoc.Domain.Interfaces.Repository;
using archUnitPoc.UI;


using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace archUnitPoc.Test
{
    public class PocTest
    {
        // Definition classes will be tested
        private static readonly Architecture architecture =
            new ArchLoader().LoadAssemblies(
                typeof(Poc).Assembly,
                typeof(ApplicationRepository).Assembly)
            .Build();

        private readonly IObjectProvider<IType> repositoryLayer =
            Types().That().ResideInAssembly(typeof(ApplicationRepository).Assembly).As("Repository Layer");

        private readonly IObjectProvider<IType> uiLayer =
            Types().That().ResideInAssembly(typeof(Poc).Assembly).As("UI Layer");

    
        [Fact]
        public void ValidateDependeceRepositoryLayer()
        {
            IArchRule rule = Types()
                .That()
                .Are(uiLayer)
                .Should()
                .NotDependOnAny(repositoryLayer)
                .Because("Forbiden");

            Assert.True(rule.HasNoViolations(architecture));
        }

         [Fact]
        public void ValidateRepositoryImplementInterface()
        {
            IArchRule rule = Classes()
                .That().ResideInAssembly(typeof(ApplicationRepository).Assembly)
                .Should() 
                .ImplementInterface(typeof(IApplicationRepository));

            rule.Check(architecture);
        }

        [Fact]
        public void ValidateRepositoryLayerClassName()
        {
            IArchRule rule = Classes()
                .That().ResideInAssembly(typeof(ApplicationRepository).Assembly)
                .Should().HaveNameEndingWith("Repository");

            rule.Check(architecture);
        }
    }
}
