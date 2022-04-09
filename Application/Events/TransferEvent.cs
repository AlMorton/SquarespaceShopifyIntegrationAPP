using Application.UseCases;
using Application.UseCases.Products;

namespace Application.Events
{
    public class TransferEvent
    {
        public Guid Id { get; } = Guid.NewGuid();        
        public CreateCollectionWIthProductsDTO CollectionDTO { get; set; }
        
    }
}
