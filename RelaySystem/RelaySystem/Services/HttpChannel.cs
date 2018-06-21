using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using Polly;
using Polly.Retry;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Services
{
    public class HttpChannel : IChannel, IDisposable
    {
        private readonly IRemoteService _subscriber;
        private readonly Queue<Message> _queue;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly RetryPolicy<HttpStatusCode> _retryPolicy;

        public HttpChannel(IRemoteService subscriber)
        {
            _subscriber = subscriber;
            _queue = new Queue<Message>();
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += SendMessage;
            _backgroundWorker.RunWorkerCompleted += MessageRecived;
            _retryPolicy = Policy.Handle<HttpRequestException>()
                .OrResult<HttpStatusCode>(result => result != HttpStatusCode.Accepted && result != HttpStatusCode.OK)
                .WaitAndRetryForever(retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public void Dispose()
        {
            _backgroundWorker?.Dispose();
        }

        public void EnqueueMessage(Message message)
        {
            _queue.Enqueue(message);
        }

        private void SendMessage(object sender, EventArgs e)
        {
            var message = _queue.Dequeue();
            _retryPolicy.Execute(() => _subscriber.ReciveMessage(message).Result);
        }

        private void MessageRecived(object sender, EventArgs e)
        {
            if (_queue.Count > 0)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }
    }
}
