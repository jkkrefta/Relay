using System;
using System.Threading.Tasks;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.ConsoleDemo
{
    public class ConsoleSubscriber : ISubscriber
    {
        private readonly string _name;

        public ConsoleSubscriber(string name)
        {
            _name = name;
        }

        public Task<bool> ReciveMessage(Message msg)
        {
            Console.WriteLine($"<<{_name} recived message: {msg.Data}>>");
            return Task.FromResult(true);
        }
    }
}