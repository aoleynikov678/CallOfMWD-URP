using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class XRPositionProvider : IPositionProvider
    {
        public Transform Transform { get; private set; }
        public void Init(Transform parent)
        {
            Transform = parent.gameObject.GetComponent<XRRig>().cameraGameObject.transform;
        }

        public void Tick()
        {
        }
    }
}