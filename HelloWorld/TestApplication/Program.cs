using HelloWorldInterfaces;
using Orleans;
using System;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //SayHelloTest().Wait();
            StreamingTest().Wait();

            Console.ReadLine();
            GrainClient.Uninitialize();
        }


        public static async Task SayHelloTest()
        {
            const long id = 0;
            const string name = "David";

            GrainClient.Initialize("ClientConfigurationForTesting.xml");
            var grain = GrainClient.GrainFactory.GetGrain<IHello>(id);

            string reply = await grain.SayHello(name);
            Console.WriteLine(reply);
        }

        public static async Task StreamingTest()
        {
            const long id = 0;

            GrainClient.Initialize("ClientConfigurationForTesting.xml");
            var senderGrain = GrainClient.GrainFactory.GetGrain<IStreamSender>(id);

            var reply = await senderGrain.Send();
            Console.WriteLine("Finished sending stream: " + reply);
        }
    }
}
