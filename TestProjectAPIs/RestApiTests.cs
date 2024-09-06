using RestSharp;

namespace TestProjectAPIs;

public class RestApiTests
{
    private readonly string baseUrl = "https://localhost:7208/api"; // Substitua com a URL correta da sua API

    [Test]
    public async Task GetProduct_ShouldReturnProduct()
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest("/Products/1", Method.Get); // Substitua com o endpoint correto
        var response = await client.ExecuteAsync<Product>(request);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
        });
        Assert.That(response.Data.Id, Is.EqualTo(1));
        Assert.That(response.Data.Price, Is.EqualTo(19.99f));
        Assert.That(response.Data.Name, Is.EqualTo("Product Example"));
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; }
}
