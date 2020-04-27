using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using lab.core;
using Photon.Pun;
using IDisposable = lab.core.IDisposable;

namespace lab.mwd
{
    public class EventsReceiverService : IEventsReceiverService, IDisposable
    {
        private readonly EventsReceiver eventsReceiver;
        private NetworkEventsBus networkEventsBus;

        public EventsReceiverService()
        {
            eventsReceiver = new EventsReceiver();
            eventsReceiver.AddEvent(NetworkEventsCodes.ChangeLevelEvent, OnChangeLevel);

            networkEventsBus = ServiceLocator.Current.Get<NetworkEventsBus>();
        }

        public void Dispose()
        {
            eventsReceiver.Dispose();
        }
        
        private void OnChangeLevel(object[] obj)
        {
            var levelPath = (string) obj[0];
            
            networkEventsBus.Fire(new OnChangeLevel(levelPath, false));
        }
    }
}