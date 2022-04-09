
using Application.UseCases;
using Application.UseCases.Products;

namespace Application.Interfaces
{
    public interface ISquareSpaceScrapper
    {
        List<CollectionItem> GetArtistCollectionItems(string url);

        ItemDTO GetItemDetails(string url);
    }
}