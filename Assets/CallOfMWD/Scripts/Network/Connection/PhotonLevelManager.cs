using lab.core;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace lab.mwd
{
    public class PhotonLevelManager : MonoBehaviour
    {
        [SerializeField] private LevelReference levelToLoad;
        
        private PhotonConnectionCallbacks roomConnector;

        private void Awake()
        {           
            roomConnector = GetComponent<PhotonConnectionCallbacks>();

            if (roomConnector == null)
            {
                Debug.LogError($"No room connector attached to {name}");
                return;
            }
            
            roomConnector.OnRoomConnected += OnRoomConnected;
            roomConnector.OnRoomDisconnected += OnRoomDisconnected;
        }

        private void OnDestroy()
        {
            if (roomConnector != null)
            {
                roomConnector.OnRoomConnected -= OnRoomConnected;
                roomConnector.OnRoomDisconnected -= OnRoomDisconnected;
            }
        }

        private void OnRoomConnected()
        {
            PhotonNetwork.LoadLevel(levelToLoad.LevelPath);
        }
        
        private void OnRoomDisconnected()
        {
            SceneManager.LoadScene(0);
        }
        

    }
}