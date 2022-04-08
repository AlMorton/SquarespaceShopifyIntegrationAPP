namespace Application.Events
{
    public class TransferEvent
    {
        public Guid Id { get; }
        public string ItemURL { get; }

        public TransferEvent(string url)
        {
            Id = Guid.NewGuid();
            ItemURL = url;
        }
    }
}
