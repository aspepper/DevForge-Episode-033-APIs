using DevForge_API_gRPC_Sample;
using Grpc.Net.Client;

namespace TestProjectAPIs;

public class GrpcApiTests
{
    private GrpcChannel? channel;
    private ProductService.ProductServiceClient _client;

    [SetUp]
    public void Setup()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:5001"); // Use a URL correta da sua API
        _client = new ProductService.ProductServiceClient(channel);
    }

    [Test]
    public async Task GetProduct_ShouldReturnProduct()
    {
        var request = new ProductRequest { Id = 1 };

        var response = await _client.GetProductAsync(request);

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.Id, Is.EqualTo(1));
            Assert.That(response.Name, Is.EqualTo("Product Example"));
            Assert.That(response.Price, Is.EqualTo(19.99f));
        });
    }

    [TearDown]
    public void Cleanup()
    {
        channel?.Dispose();
    }
}