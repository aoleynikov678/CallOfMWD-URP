using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace lab.mwd
{
    public class PlayerCreator : MonoBehaviourPun
    {
        [SerializeField] private string playerName;
        private LocalPlayer localPlayer;
        
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => PhotonNetwork.InRoom);

            Debug.Log("Connected to room");
            
            localPlayer = FindObjectOfType<LocalPlayer>();

            if (localPlayer == null)
            {
                PhotonNetwork.Instantiate(playerName, Vector3.zero, Quaternion.identity);
            }
            
        }
    }
}