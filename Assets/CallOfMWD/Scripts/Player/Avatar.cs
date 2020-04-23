using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class Avatar : MonoBehaviour
    {
        [SerializeField] private XRRig xrRig;
        private Transform head;

        public void SetRig(XRRig rig)
        {
            xrRig = rig;
            head = xrRig.cameraGameObject.transform;
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