using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class PetStoreClient
{
	private static readonly HttpClient client = new HttpClient();

	// Base URL of the PetStore API
	private const string baseUrl = "https://petstore.swagger.io/v2/pet/";


	public static async Task<List<Pet>> GetPetsByStatusAsync(string status)
	{
		try
		{
			var response = await client.GetAsync($"{baseUrl}findByStatus?status={status}");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Pet>>(content);
			}
			else
			{
				Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
				return new List<Pet>();
			}
		}
		catch (HttpRequestException ex)
		{
			Console.WriteLine($"Network Error: {ex.Message}");
			return new List<Pet>();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Unexpected Error: {ex.Message}");
			return new List<Pet>();
		}
	}
}