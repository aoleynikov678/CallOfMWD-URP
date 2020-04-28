using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class InteractableCollidersSwitcher : MonoBehaviourPun
    {
        private List<Collider> colliders = new List<Collider>();

        private void Awake()
        {
            colliders = GetComponentsInChildren<Collider>().ToList();
        }

        public void OnInteract(XRBaseInteractor interactor)
        {
            colliders.ForEach(c => c.enabled = false);
        }
        
        public void OnInteractFinish(XRBaseInteractor interactor)
        {
            colliders.ForEach(c => c.enabled = true);
        }
    }
}