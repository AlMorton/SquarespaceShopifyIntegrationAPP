
namespace Infrastructure.Webscrappers
{
    public interface ISquareSpaceScrapper
    {
        List<CollectionItem> GetArtistCollectionItems(string url);

        ItemDTO GetItemDetails(string url);
    }
}