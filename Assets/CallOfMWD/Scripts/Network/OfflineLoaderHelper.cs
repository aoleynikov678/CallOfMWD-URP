using Photon.Pun;
using UnityEngine;

namespace lab.mwd
{
    public class OfflineLoaderHelper : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            if (PhotonNetwork.IsConnected == false)
            {
                PhotonNetwork.OfflineMode = true;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.CreateRoom(Random.Range(0, 9999) + "random room");
        }

    }
}