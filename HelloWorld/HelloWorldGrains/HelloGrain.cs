using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using HelloWorldInterfaces;

namespace HelloWorldGrains
{
    /// <summary>
    /// Orleans grain implementation class HelloGrain.
    /// </summary>
    public class HelloGrain : Orleans.Grain, HelloWorldInterfaces.IHello
    {
        async Task<string> HelloWorldInterfaces.IHello.SayHello(string name)
        {
            Console.WriteLine("HelloGrain input: " + name);
            var goodbyeGrain = GrainFactory.GetGrain<IGoodbye>(0);
            var goodbyeResult = await goodbyeGrain.SayGoodbye(name);

            return "Hello, " + name + "!" + " " + goodbyeResult;
        }
    }
}
