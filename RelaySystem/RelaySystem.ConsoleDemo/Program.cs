using System;
using RelaySystem.Abstract;
using RelaySystem.Models;

namespace RelaySystem.ConsoleDemo
{
    class Program
    {
        private static IRelay _relay;

        static void Main(string[] args)
        {
            _relay = new Relay();
            
            _relay.Subscribe(new ConsoleSubscriber("1"));
            _relay.Subscribe(new ConsoleSubscriber("2"));
            _relay.Subscribe(new ConsoleSubscriber("3"));

            Console.WriteLine("Press any key to relay message");
            Console.WriteLine("Press q to quit");

            RunTestLoop();
        }

        private static void RunTestLoop()
        {
            var run = true;
            var count = 0;
            while (run)
            {
                run = HandleConsoleInput();
                count++;
                _relay.SendMessage(new Message {Data = count.ToString()});
            }
        }

        private static bool HandleConsoleInput()
        {
            var consoleKeyInfo = Console.ReadKey(false);
            Console.WriteLine();
            return consoleKeyInfo.Key != ConsoleKey.Q;
        }
    }
}
