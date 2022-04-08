﻿using System.Threading.Channels;

namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public class TransferService : BackgroundService
    {
        private readonly TransferQueue _queue;

        public TransferService(TransferQueue queue)
        {
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _queue.ListenForEventsAsync();
        }
    }

    public class TransferQueue : IQueueTask, ITaskViewer
    {
        private readonly Channel<TransferEvent> _tasks = Channel.CreateUnbounded<TransferEvent>();
        public List<TransferEvent> EventsBeingProccessed { get; private set; } = new List<TransferEvent>();
        public async Task ListenForEventsAsync()
        {
            await foreach (var @event in _tasks.Reader.ReadAllAsync())
            {
                EventsBeingProccessed.Add(@event);
            }
        }

        public async Task QueueEvent(TransferEvent @event)
        {
            await _tasks.Writer.WriteAsync(@event, new CancellationToken());
        }
    }

    public interface IQueueTask
    {
        Task QueueEvent(TransferEvent @event);
    }
    public interface ITaskViewer
    {
        List<TransferEvent> EventsBeingProccessed { get; }
    }

    public class TransferEvent
    {
        public Guid Id { get; set; }

    }
}
