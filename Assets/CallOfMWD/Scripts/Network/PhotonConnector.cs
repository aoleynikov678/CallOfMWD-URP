using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace lab.mwd
{
    public class PhotonConnector : MonoBehaviourPunCallbacks
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

            PhotonNetwork.JoinLobby();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected from master: {cause}");
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Connected to lobby");
        }
    }
}