using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using Orleans.Streams;

namespace HelloWorldGrains
{
    [ImplicitStreamSubscription("RANDOMDATA")]
    public class StreamReceiverGrain : Grain, HelloWorldInterfaces.IStreamReceiver
    {
        public async override Task OnActivateAsync()
        {
            Console.WriteLine("StreamReceiverGrain activated");
            //Create a GUID based on our GUID as a grain
            var guid = this.GetPrimaryKey();
            //Get one of the providers which we defined in config
            var streamProvider = GetStreamProvider("SMSProvider");
            //Get the reference to a stream
            var stream = streamProvider.GetStream<int>(guid, "RANDOMDATA");
            //Set our OnNext method to the lambda which simply prints the data, this doesn't make new subscriptions
            await stream.SubscribeAsync(async (data, token) =>
            {
                Console.WriteLine("StreamReceiverGrain got event: " + data);
                await Task.Delay(1);
            });
        }
    }
}
