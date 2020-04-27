using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace lab.mwd
{
    // <summary>
    /// Базовый класс для отправки ивентов по сети
    /// </summary>
    public class EventsSender
    {
        public void SendData(byte eventCode, object[] data, ReceiverGroup receiverGroup)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = receiverGroup};
            SendOptions sendOptions = new SendOptions { Reliability = true };
            PhotonNetwork.RaiseEvent(eventCode, data, raiseEventOptions, sendOptions);
            
            Debug.Log($"Network event sent: {eventCode}");

            foreach (var d in data)
            {
                Debug.Log($"--- {d}");
            }
        }
    }
}