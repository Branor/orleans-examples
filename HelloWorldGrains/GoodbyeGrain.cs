using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;

namespace HelloWorldGrains
{
    /// <summary>
    /// Orleans grain implementation class GoodbyeGrain.
    /// </summary>
    public class GoodbyeGrain : Grain, HelloWorldInterfaces.IGoodbye
    {
        Task<string> HelloWorldInterfaces.IGoodbye.SayGoodbye(string name)
        {
            Console.WriteLine("GoodbyeGrain input: " + name);

            return Task.FromResult("Goodbye, " + name + "!");
        }
    }
}
