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
public List<Pet> GetPetsByCategoryAndSortByName(List<Pet> pets)
{
    return pets
        .GroupBy(pet => pet.Category.Name)
        .OrderBy(g => g.Key)
        .SelectMany(group => group.OrderByDescending(p => p.Name))
        .ToList();
}
