using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace lab.mwd
{
    public class PhotonLeaveRoomButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }
            
            button.onClick.AddListener(LeaveRoom);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(LeaveRoom);
        }

        private void LeaveRoom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
            }
        }
    }
}