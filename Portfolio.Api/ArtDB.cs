using Portfolio.Api.DTOs;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio.Api;

public interface IClient
{
    Task<SpeciesDetail> GetSpecies(int id);
}

public class ArtDB(HttpClient httpClient) : IClient
{
    public async Task<SpeciesDetail> GetSpecies(int id)
    {

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://api.artdatabanken.se/information/v1/speciesdataservice/v1/speciesdata/texts?taxa={id}");
        request.Headers.Add("Ocp-Apim-Subscription-Key", "332fd41148bc47138313ef715cc3d7d1");

        var response = await httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        var speciesDetail= JsonSerializer.Deserialize<List<SpeciesDetail>>(result);
        return speciesDetail[0];

    }
}
