using System.Net;
using System.Threading.Tasks;
using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface IRemoteService
    {
        Task<HttpStatusCode> ReciveMessage(Message msg);
    }
}
