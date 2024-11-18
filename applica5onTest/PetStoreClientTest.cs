using Xunit;

public class PetStoreClientTests
{
    [Fact]
    public async Task GetPetsByStatusAsync_ReturnsPets_WhenApiCallIsSuccessful()
    {
        // Arrange
        var pets = await PetStoreClient.GetPetsByStatusAsync("available");

        // Act & Assert
        Assert.NotNull(pets);
        Assert.True(pets.Count > 0, "No pets were returned.");
    }
}
