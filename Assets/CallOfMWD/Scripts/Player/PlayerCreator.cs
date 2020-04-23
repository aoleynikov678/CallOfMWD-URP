using Photon.Pun;
using UnityEngine;

namespace lab.mwd
{
    public class PlayerCreator : MonoBehaviourPun
    {
        [SerializeField] private string playerName;
        private LocalPlayer localPlayer;
        
        private void Awake()
        {
            localPlayer = FindObjectOfType<LocalPlayer>();

            if (localPlayer == null)
            {
                PhotonNetwork.Instantiate(playerName, Vector3.zero, Quaternion.identity);
            }
        }
    }
}