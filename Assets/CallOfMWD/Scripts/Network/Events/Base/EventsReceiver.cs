using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

namespace lab.mwd
{
    /// <summary>
    /// Базовый класс для приёма ивентов по сети
    /// </summary>
    public class EventsReceiver
    {
        // мэппинг кода ивента к ф-ции
        private readonly Dictionary<byte, Action<object[]>> receiveEventsActions = new Dictionary<byte, Action<object[]>>();

        public EventsReceiver()
        {
            PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
        }
        
        public void Dispose()
        {
            PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
        }
        
        public void AddEvent(byte eventCode, Action<object[]> action)
        {
            receiveEventsActions.Add(eventCode, action);
        }

        public void RemoveEvent(byte eventCode, Action<object[]> action)
        {
            receiveEventsActions.Remove(eventCode);
        }
        
        private void OnEvent(EventData photonEvent)
        {
            byte eventCode = photonEvent.Code;

            Debug.Log("RECEIVED EVENT " + eventCode);
            
            if (receiveEventsActions.ContainsKey(eventCode))
            {
                object[] data = (object[])photonEvent.CustomData;
                receiveEventsActions[eventCode].Invoke(data);

                Debug.Log($"Network event received: {eventCode}");

                foreach (var d in data)
                {
                    Debug.Log($"--- {d}");
                }
            }
        }
    }
}