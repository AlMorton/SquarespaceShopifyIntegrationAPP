using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.APIClients.ShopifyJSONModels
{
    public class Root_CustomCollection<TJsonCollectionModel>
    {
        public TJsonCollectionModel custom_collection { get; set; }
    }
    public class CustomCollectionPost
    {
        public string title { get; set; }
    }

    public class CustomCollectionEntity
    {
        public long Id { get; set; }
    }

}
