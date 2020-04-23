using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class NetworkPlayer : MonoBehaviourPun
    {
        [SerializeField] private List<GameObject> destroyObjects = new List<GameObject>();
        [SerializeField] private XRRig xrRigPrefab;
        [SerializeField] private Avatar avatar;

        private XRRig xrRig;
        
        private void Awake()
        {
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

                avatar.SetRig(xrRig);
            }
        }
    }
}