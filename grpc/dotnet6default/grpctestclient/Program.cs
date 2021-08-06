using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using grpctest;

namespace Client
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);

            Console.WriteLine("Shutting down");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}