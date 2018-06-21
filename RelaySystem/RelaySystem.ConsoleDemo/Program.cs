using System;
using RelaySystem.Factories;
using RelaySystem.Models;
using RelaySystem.Services;

namespace RelaySystem.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var relayService = new RelayService();
            var subscriberService = new SubscriberService(new ChannelFactory(), relayService);
            
            subscriberService.Subscribe(new ConsoleSubscriber("1"));
            subscriberService.Subscribe(new ConsoleSubscriber("2"));
            subscriberService.Subscribe(new ConsoleSubscriber("3"));

            Console.WriteLine("Press any key to relay message");
            Console.WriteLine("Press q to quit");

            RunTestLoop(relayService);
        }

        private static void RunTestLoop(RelayService relayService)
        {
            var run = true;
            var count = 0;
            while (run)
            {
                run = HandleConsoleInput();
                count++;
                relayService.RelayMessage(new Message {Data = count.ToString()});
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
