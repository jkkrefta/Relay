namespace RelaySystem.Abstract
{
    internal interface IChannelFactory
    {
        IChannel CreateBinaryChannel(ISubscriber subscriber);
        IChannel CreateHttpChannel(IRemoteService subscriber);
    }
}