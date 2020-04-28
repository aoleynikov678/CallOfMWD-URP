using System.Collections.Generic;
using System.Linq;
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
        
        private List<XRBaseControllerInteractor> interactors = new List<XRBaseControllerInteractor>();

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
                avatar.DisableRendering();

                interactors = xrRig.GetComponentsInChildren<XRBaseControllerInteractor>().ToList();
            }
        }

        public void DestroyPlayer()
        {
            Destroy(xrRig.gameObject);
            PhotonNetwork.Destroy(gameObject);
        }

        // TODO сделать тут коллбэк на переключение сцены
        private void Update()
        {
            foreach (var interactor in interactors)
            {
                if (interactor.interactionManager == null)
                {
                    interactor.interactionManager = FindObjectOfType<XRInteractionManager>();
                }
            }
        }
    }
}