using System;

namespace lab.mwd
{
    public interface IRoomConnector
    {
        event Action OnRoomConnected;
        event Action OnRoomDisconnected;
    }
}