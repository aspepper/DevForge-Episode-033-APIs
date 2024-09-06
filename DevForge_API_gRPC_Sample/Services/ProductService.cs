using Grpc.Core;
using static DevForge_API_gRPC_Sample.ProductService;

namespace DevForge_API_gRPC_Sample.Services;

public class ProductService : ProductServiceBase
{
    public override Task<ProductResponse> GetProduct(ProductRequest request, ServerCallContext context)
    {
        // Simulação de produto para o exemplo
        return Task.FromResult(new ProductResponse
        {
            Id = request.Id,
            Name = "Product Example",
            Price = 19.99f
        });
    }
}
