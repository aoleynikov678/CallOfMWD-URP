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
    }
}