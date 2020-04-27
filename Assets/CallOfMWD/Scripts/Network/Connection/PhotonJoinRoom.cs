using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace lab.mwd
{
    public class PhotonJoinRoom : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button button;
        [SerializeField] private RoomEntry roomEntry;

        private bool joining = false;

        private void Awake()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }
            
            button.onClick.AddListener(JoinRoom);

            if (roomEntry == null)
            {
                roomEntry = GetComponent<RoomEntry>();
            }
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }

        private void JoinRoom()
        {
            if (!PhotonNetwork.IsConnected || joining)
                return;

            joining = true;
            PhotonNetwork.JoinRoom(roomEntry.RoomInfo.Name);
        }
    }
}