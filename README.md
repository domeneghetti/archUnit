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
  - The package name changed, I finded it with name: TngTech.ArchUnitNET.xUnit 
  - The package installed by cli on linux environment broke build, it was possible install by Nuget Manager on Windows environment
```
After created a project, I just create a simple classes for validate architecture rules.

Lets running the project, just check it's ok
- open your terminal
- navigate to project archUnit.UI
- execute command dotnet run

Do you'll see 3 logs, looks like this print:

![Result Test Project Running](images/runningProject.png)

Ok... the project works! 
Let's see the class Poc in archUnitPoc.UI -> Poc.cs

![Poc Class](images/PocClass.png)

Look at:
- Line 2: There is a reference to repository layer, but, I don't want to UI layer access my repository layer
- Line 17 and 18: Just explication the problems
- Line 19 and 20: Creating repository object and using it to get data
- Line 22: Just text for solution
- Line 23: Solved problem the archecture test will show, dont forgot remove line 2, 17 to 20 too

Now, back to terminal and access the project archUnitPoc.Test and execute command 
```
dotnet test
```

Look at this problem:
![](images/UnitTestFail.png)

our archUnitPoc.Test.PocTest.ValidateDependeceRepositoryLayer failed!!
Did you remember Poc class at line 18?

- Second Problem: I don't want to UI Layer has access to Repository Layer

So, with archUnit we can guarantee it!

Lets see the tests now and understand how it was created.

The first part:
- Lines 1 to 11: References assemblies of ArchUnitNET, xUnit and projects of our solution

- Line 18: Created a instance of Architecture loading our projects assemblies to using on validations

- Lines 24 to 28: Creating object of projects to using on validations, its not the same thing of line 18, on line 18 we crated object of archUnitNet and loaded our assemblies, now we are create a object provider of our projects loaded on line 18

![](images/archUnit.Test-1.png)

The second part we have our architecture tests:
- Test ValidateDependeceRepositoryLayer: We are creating validation to our repository layer no be using o ui layer, about the problem created on Poc class line 17 to 23

- TestValidateRepositoryImplementInterface: We are creating validation to garantees our ApplicationRepository implements contracts using interface IApplicationRepository

- Test ValidateRepositoryLayerClassName: We are creating validation to garantees all class on repository layer has end with "Repository" on name

![](images/archUnit.Test-2.png)


After fixed the problems get on test ValidateDependeceRepositoryLayer and running tests againg all test works with success:

![](images/solution.png)


Can you see more about this lib on site: https://archunitnet.readthedocs.io/en/latest/guide/
