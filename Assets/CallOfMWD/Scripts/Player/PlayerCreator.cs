using System.Collections;
using System.Linq;
using Photon.Pun;
using UnityEngine;

namespace lab.mwd
{
    public class PlayerCreator : MonoBehaviourPun
    {
        [SerializeField] private string playerName;
        private NetworkPlayer networkPlayer;
        
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => PhotonNetwork.InRoom);

            networkPlayer = FindObjectsOfType<NetworkPlayer>().FirstOrDefault(p => p.photonView.IsMine);

            if (networkPlayer == null)
            {
                Debug.Log("---Instantiate local---");
                PhotonNetwork.Instantiate(playerName, Vector3.zero, Quaternion.identity);
            }
            
        }
    }
}