# archUnit
This project was created to validate an archUnit lib, some codes has archtecture problems.
I expecte create guarantees on solution architecture to be implemented and respected in all the project and fixes

For create this project I used the commands below:
```
# create solution
dotnet new sln --name archUnitPoc.sln 

# create projects
dotnet new classlib -n archUnitPoc.Repository
dotnet new classlib -n archUnitPoc.Domain  
dotnet new console -n archUnitPoc.UI 
dotnet new xunit -n archUnitPoc.Test 

# adding projects on solution
dotnet sln add archUnitPoc.Domain/archUnitPoc.Domain.csproj   
dotnet sln add archUnitPoc.Repository/archUnitPoc.Repository.csproj
dotnet sln add archUnitPoc.UI/archUnitPoc.UI.csproj
dotnet sln add archUnitPoc.Test/archUnitPoc.Test.csproj

# create references
dotnet add archUnitPoc.Repository/archUnitPoc.Repository.csproj reference archUnitPoc.Domain/archUnitPoc.Domain.csproj
dotnet add archUnitPoc.Test/archUnitPoc.Test.csproj reference archUnitPoc.Domain/archUnitPoc.Domain.csproj
dotnet add archUnitPoc.Test/archUnitPoc.Test.csproj reference archUnitPoc.Repository/archUnitPoc.Repository.csproj
dotnet add archUnitPoc.Test/archUnitPoc.Test.csproj reference archUnitPoc.UI/archUnitPoc.UI.csproj       
dotnet add archUnitPoc.UI/archUnitPoc.UI.csproj reference archUnitPoc.Domain/archUnitPoc.Domain.csproj        
dotnet add archUnitPoc.UI/archUnitPoc.UI.csproj reference archUnitPoc.Repository/archUnitPoc.Repository.csproj

# Install Packages
 # archUnitPoc.UI
 dotnet add package Microsoft.Extensions.DependencyInjection

# archUnitPoc.Test
I tried install ArchUnitNET.xUnit using documentation I had two problems:
 - The package name changes, I find it with name: TngTech.ArchUnitNET.xUnit 
 - The package installed by cli on linux environment broked build, it was possible install by Nuget Manager on Windows environment
```

