
using Application.UseCases;
using Application.UseCases.Products;
using static Application.UseCases.Products.Product_Root;

namespace Application.Interfaces
{
    public interface IShopifyClient
    {
        Task<ProductEntity> CreateProduct(Product product);
    }
}