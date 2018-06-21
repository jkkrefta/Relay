﻿using System.Threading.Tasks;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.Benchmark
{
    public class DummyBinarySubscriber : ISubscriber
    {
        public Task<bool> ReciveMessage(Message msg)
        {
            return Task.FromResult(true);
        }
    }
}