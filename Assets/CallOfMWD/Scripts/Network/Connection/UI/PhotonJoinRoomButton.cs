using lab.core;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace lab.mwd
{
    public class PhotonJoinRoomButton : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button button;
        [SerializeField] private RoomEntry roomEntry;

        private bool joining = false;
        private ISettingsProvider settingsProvider;

        private void Awake()
        {
            settingsProvider = ServiceLocator.Current.Get<ISettingsProvider>();
            
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

            SetRole();
            joining = true;
            PhotonNetwork.JoinRoom(roomEntry.RoomInfo.Name);
        }
        
        private void SetRole()
        {
            var customProperties = new ExitGames.Client.Photon.Hashtable
            {
                {
                    PhotonProperties.CustomProp(RoomProperty.NetworkRole),
                    settingsProvider.GameSettings.NetworkSettings.NetworkRole.ToString()
                }
            };
            PhotonNetwork.SetPlayerCustomProperties(customProperties);
        }
    }
}