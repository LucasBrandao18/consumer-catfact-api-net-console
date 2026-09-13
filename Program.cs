using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsumerCatFactApi;

internal class Program
{
    private static async Task<int> Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        using HttpClient client = new()
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        try
        {
            // Consulta o endpoint e converte o JSON em um objeto C# (item a).
            CatFact? catFact = await client.GetFromJsonAsync<CatFact>(
                "https://catfact.ninja/fact");

            if (catFact is null || string.IsNullOrWhiteSpace(catFact.Fact))
            {
                Console.Error.WriteLine("A API não retornou um fato sobre gatos.");
                return 1;
            }

            // Exibe o fato recebido no formato solicitado no item b.
            Console.WriteLine("Fato sobre Gatos:");
            Console.WriteLine(catFact.Fact);
            return 0;
        }
        catch (HttpRequestException)
        {
            Console.Error.WriteLine(
                "Não foi possível consultar a API. Verifique sua conexão e tente novamente.");
            return 1;
        }
        catch (TaskCanceledException)
        {
            Console.Error.WriteLine("A consulta demorou demais. Tente novamente.");
            return 1;
        }
        catch (JsonException)
        {
            Console.Error.WriteLine("A API retornou dados em um formato inválido.");
            return 1;
        }
    }
}

internal class CatFact
{
    [JsonPropertyName("fact")]
    public string? Fact { get; set; }

    [JsonPropertyName("length")]
    public int Length { get; set; }
}
