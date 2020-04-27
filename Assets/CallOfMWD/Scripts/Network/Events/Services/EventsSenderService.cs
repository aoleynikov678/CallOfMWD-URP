using ExitGames.Client.Photon;
using JetBrains.Annotations;
using lab.core;
using Photon.Pun;
using Photon.Realtime;

namespace lab.mwd
{
    public class EventsSenderService : IEventsSenderService
    {
        private readonly EventsSender eventsSender;
        
        public EventsSenderService()
        {
            eventsSender = new EventsSender();

            var networkEventsBus = ServiceLocator.Current.Get<NetworkEventsBus>();
            networkEventsBus.AddListener<OnChangeLevel>(ChangeLevel);
        }

        private void ChangeLevel(OnChangeLevel onChangeLevel)
        {
            if (!onChangeLevel.Owner)
                return;
                
            eventsSender.SendData(NetworkEventsCodes.ChangeLevelEvent, new object[] {onChangeLevel.LevelPath}, ReceiverGroup.Others);
        }
    }
}