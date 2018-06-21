namespace RelaySystem.Abstract
{
    public interface IChannelFactory
    {
        IChannel CreateBinaryChannel(ISubscriber subscriber);
        IChannel CreateHttpChannel(IRemoteService subscriber);
    }
}