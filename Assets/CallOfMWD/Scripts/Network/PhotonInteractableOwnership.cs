using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class PhotonInteractableOwnership : MonoBehaviourPun, IPunOwnershipCallbacks
    {
        private void Awake()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        private void OnDestroy()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
        
        public void OnInteract(XRBaseInteractor interactor)
        {
            base.photonView.RequestOwnership();
        }

        public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
        {
            if (targetView != base.photonView)
                return;
            
            base.photonView.TransferOwnership(requestingPlayer);
        }

        public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
        {
            if (targetView != base.photonView)
                return;
        }
    }
}