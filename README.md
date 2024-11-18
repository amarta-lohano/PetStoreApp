# PetStore Application

## Description

This application interacts with the PetStore API to retrieve available pets, group them by category, and display them sorted in reverse order by their name. The code uses a simple console application in C#.

## Technologies Used

- C#
- .NET Core
- xUnit for unit testing
- Moq for mocking dependencies
- HttpClient for API requests
- Newtonsoft.Json for JSON deserialization

## How to Run the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo-url.git](https://github.com/amarta-lohano/PetStoreApp.git
2. Install .NET SDK.
3. Run the application:
   ```bash
   dotnet run
## ChatGPT Assistance

During the development of this solution, some code was generated using ChatGPT to assist with tasks reading pets data.

### Example ChatGPT Interaction for Fetching Pets by Category:


```csharp
var pets = await PetStoreClient.GetPetsByStatusAsync("available");  
var groupedPets = pets  
    .Where(p => p.Category != null)  
    .GroupBy(p => p.Category.Name)  
    .OrderBy(g => g.Key);  
foreach (var group in groupedPets) {  
    Console.WriteLine($"Category: {group.Key}");  
    foreach (var pet in group.OrderByDescending(p => p.Name)) {  
        Console.WriteLine($" - {pet.Name}");  
    }  
}  

Adding a Test Project


bash
Copy code
dotnet new xunit -n applica5on.Tests  
dotnet add applica5on.Tests reference applica5on

Then write a test for the GetPetsByStatusAsync method:

```csharp
[Fact]  
public async Task GetPetsByStatusAsync_ReturnsAvailablePets() {  
    var pets = await PetStoreClient.GetPetsByStatusAsync("available");  
    Assert.NotNull(pets);  
    Assert.All(pets, p => Assert.Equal("available", p.Status));  
}

Debugging Issues with Git and Repository Management
Set Your Global Git Configuration: After manually creating the .gitconfig file, open Git Bash or Command Prompt and run the following commands:

   ```bash
git config --global user.email "your-email@example.com"
git config --global user.name "Your Name"


git init  
git add .  
git commit -m "Initial commit"  
git branch -M main  
git remote add origin <repository_url>  
git push -u origin main  
