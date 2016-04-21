using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using Orleans.Streams;

namespace HelloWorldGrains
{
    public class StreamSenderGrain : Grain, HelloWorldInterfaces.IStreamSender
    {
        public async Task<bool> Send()
        {
            //Create a GUID based on our GUID as a grain
            var guid = this.GetPrimaryKey();
            //Get one of the providers which we defined in config
            var streamProvider = GetStreamProvider("SMSProvider");
            //Get the reference to a stream
            var stream = streamProvider.GetStream<int>(guid, "RANDOMDATA");
            // Send some data into the stream
            Enumerable.Range(1, 20).ToList().ForEach(async i =>
            {
                Console.WriteLine("StreamSenderGrain sending event: " + i);
                await stream.OnNextAsync(i);
            });

            return true;
        }
    }
}
