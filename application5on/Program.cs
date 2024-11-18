using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Fetch all pets with status "available"
            var pets = await PetStoreClient.GetPetsByStatusAsync("available");

            if (pets == null || pets.Count == 0)
            {
                Console.WriteLine("No pets found.");
                return;
            }

            var filteredPets = pets
                    .Where(p => p.Category?.Name != null)  // Exclude pets with null category name
                    .ToList();

            // Group pets by category name (after filtering out null category names)
            var groupedPets = filteredPets
                .GroupBy(p => p.Category.Name)  // Group by category name (string)
                .OrderBy(g => g.Key)  // Sort categories alphabetically
                .ToList();

            // Print pets grouped by category, sorted in reverse order by name
            foreach (var categoryGroup in groupedPets)
            {
                // Print the category name (group key)
                Console.WriteLine($"Category: {categoryGroup.Key}");

                // Sort the pets within each category in reverse order by name
                var sortedPets = categoryGroup.OrderByDescending(p => p.Name).ToList();

                foreach (var pet in sortedPets)
                {
                    // Print the pet's name
                    Console.WriteLine($"Name - {pet.Name}");

                    // Optionally, print the pet's tags if available
                    if (pet.Tags != null && pet.Tags.Any())
                    {
                        Console.WriteLine("  Tags:");
                        foreach (var tag in pet.Tags)
                        {
                            Console.WriteLine($"    - {tag.Name}");
                        }
                    }

                    // Optionally, print the pet's photo URLs if available
                    if (pet.PhotoUrls != null && pet.PhotoUrls.Any())
                    {
                        Console.WriteLine("  Photos:");
                        foreach (var url in pet.PhotoUrls)
                        {
                            Console.WriteLine($"    - {url}");
                        }
                    }

                    Console.WriteLine(); // Blank line between pets
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
