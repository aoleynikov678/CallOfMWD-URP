using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class LocalPlayer : MonoBehaviourPun
    {
        [SerializeField] private List<GameObject> destroyObjects = new List<GameObject>();
        [SerializeField] private XRRig xrRigPrefab;

        private XRRig xrRig;
        private static LocalPlayer localPlayer;
        
        private void Awake()
        {
            localPlayer = this;
            DontDestroyOnLoad(gameObject);

            if (PhotonNetwork.IsConnected && photonView.IsMine == false)
            {
                foreach (var obj in destroyObjects)
                {
                    Destroy(obj);
                }
            }
            else
            {
                xrRig = Instantiate(xrRigPrefab);
                DontDestroyOnLoad(xrRig.gameObject);
            }
        }
    }
}