using System.Threading.Tasks;
using Orleans;

namespace HelloWorldInterfaces
{
    /// <summary>
    /// Orleans grain communication interface IHello
    /// </summary>
    public interface IStreamSender : IGrainWithIntegerKey
    {
        Task<bool> Send();
    }
}
