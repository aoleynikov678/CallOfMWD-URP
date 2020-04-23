using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace lab.mwd
{
    public class PhotonRoomCreator : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button createButton;
        [SerializeField] private TMP_Text roomNameText;

        private readonly RoomOptions options = new RoomOptions();

        private void Awake()
        {
            createButton.onClick.AddListener(() => { CreateRoom(roomNameText.text); });
        }

        private void OnDestroy()
        {
            createButton.onClick.RemoveAllListeners();
        }

        public void CreateRoom(string roomName)
        {
            if (!PhotonNetwork.IsConnected)
                return;
            
            options.MaxPlayers = 8;
            PhotonNetwork.JoinOrCreateRoom(roomNameText.text, options, TypedLobby.Default);
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