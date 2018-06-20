using System.Threading.Tasks;
using RelaySystem.Models;

namespace RelaySystem.Abstract
{
    public interface ISubscriber
    {
        Task<bool> ReciveMessage(Message msg);
    }
}
