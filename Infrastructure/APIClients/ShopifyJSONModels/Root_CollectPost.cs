namespace Infrastructure.APIClients.ShopifyJSONModels
{
    public class Root_CollectPost
    {
        public CollectLinkPost collect { get; set; }
    }

    public class CollectLinkPost
    {
        public int product_id { get; set; }
        public int collection_id { get; set; }
    }
}
