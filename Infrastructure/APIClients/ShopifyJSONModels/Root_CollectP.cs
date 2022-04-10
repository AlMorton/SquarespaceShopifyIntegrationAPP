namespace Infrastructure.APIClients.ShopifyJSONModels
{
    public class Root_Collect<TCollect>
    {
        public TCollect collect { get; set; }
    }

    public class CollectLinkPost
    {
        public long product_id { get; set; }
        public long collection_id { get; set; }
    }

    public class CollectEntity
    {
        public long id { get; set; }
        public long collection_id { get; set; }
        public long product_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int position { get; set; }
        public string sort_value { get; set; }
    }
}
