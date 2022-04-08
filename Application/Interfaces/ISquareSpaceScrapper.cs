
using Application.UseCases;

namespace Application.Interfaces
{
    public interface ISquareSpaceScrapper
    {
        List<CollectionItem> GetArtistCollectionItems(string url);

        ItemDTO GetItemDetails(string url);
    }
}