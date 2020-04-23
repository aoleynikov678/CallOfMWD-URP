using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace lab.mwd
{
    public class PhotonMasterConnector : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            Debug.Log("Connecting to master");

            PhotonNetwork.NickName = GameSettings.NetworkSettings.NickName;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log($"Connected to master {PhotonNetwork.LocalPlayer.NickName}");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected from master: {cause}");
        }
    }
}