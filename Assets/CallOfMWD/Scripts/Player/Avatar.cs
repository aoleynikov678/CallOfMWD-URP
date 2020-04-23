using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class Avatar : MonoBehaviour
    {
        [SerializeField] private XRRig xrRig;
        private Transform head;
        private List<Renderer> renderers = new List<Renderer>();

        public void SetRig(XRRig rig)
        {
            xrRig = rig;
            head = xrRig.cameraGameObject.transform;
        }

        public void DisableRendering()
        {
            renderers = GetComponentsInChildren<Renderer>().ToList();
            foreach (var rend in renderers)
            {
                rend.enabled = false;
            }
        }

        private void Update()
        {
            if (head == null)
                return;

            transform.position = head.position;
            transform.rotation = Quaternion.Euler(0, head.transform.rotation.eulerAngles.y, 0);
        }
    }
}