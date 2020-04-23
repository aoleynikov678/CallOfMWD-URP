using lab.core;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace lab.mwd
{
    public class PhotonConnector : MonoBehaviourPunCallbacks
    {
        private ISettingsProvider sp;
        
        private void Start()
        {
            sp = ServiceLocator.Current.Get<ISettingsProvider>();

            PhotonNetwork.NickName = sp.GameSettings.NetworkSettings.NickName;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }


    }
}