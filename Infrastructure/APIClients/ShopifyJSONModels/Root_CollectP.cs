namespace Infrastructure.APIClients.ShopifyJSONModels
{
    public class Root_Collect<TCollect>
    {
        public TCollect collect { get; set; }
    }

    public class CollectLinkPost
    {
        public int product_id { get; set; }
        public int collection_id { get; set; }
    }

    public class CollectEntity
    {
        public int id { get; set; }
        public int collection_id { get; set; }
        public int product_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int position { get; set; }
        public string sort_value { get; set; }
    }
}
