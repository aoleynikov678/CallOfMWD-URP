using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace lab.mwd
{
    public class PhotonDebugCallbacks : MonoBehaviourPunCallbacks
    {
        public override void OnConnectedToMaster()
        {
            Debug.Log($"Connected to master {PhotonNetwork.LocalPlayer.NickName}");
        }
        
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected from master: {cause}");
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Connected to lobby");
        }
        
        public override void OnCreatedRoom()
        {
            Debug.Log($"Room created {PhotonNetwork.CurrentRoom.Name}");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.LogError($"Room creation failed {returnCode}: {message}");
        }

        public override void OnJoinedRoom()
        {
            Debug.Log($"Joined room {PhotonNetwork.CurrentRoom.Name}");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError($"Room joining failed {returnCode}: {message}");
        }
    }
}