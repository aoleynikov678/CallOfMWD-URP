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
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to master");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected from master: {cause}");
        }
    }
}