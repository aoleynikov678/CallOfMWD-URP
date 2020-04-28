using lab.core;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{
    public class KeyboardPositionProvider : IPositionProvider
    {
        private IPlayerInputService playerInputService;
        public Transform Transform { get; private set; }

        private Transform cameraTransform;

        private XRRig rig;
        
        public void Init(Transform parent)
        {
            playerInputService = ServiceLocator.Current.Get<IPlayerInputService>();
            Transform = parent;
            cameraTransform = parent.gameObject.GetComponent<XRRig>().cameraGameObject.transform;

            rig = parent.gameObject.GetComponent<XRRig>();
            
            rig.MatchRigUpCameraForward(cameraTransform.up, cameraTransform.forward);
            
        }

        public void Tick()
        {
            //cameraTransform.localPosition = Vector3.zero;

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Transform.position -= new Vector3(0, 0.05f, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                Transform.position += new Vector3(0, 0.05f, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                
                rig.RotateAroundCameraPosition(Vector3.up, -100 * Time.deltaTime);
                //Transform.RotateAround(rotateTarget.transform.position, rotationMask, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rig.RotateAroundCameraPosition(Vector3.up, 100 * Time.deltaTime);
                //Transform.RotateAround(rotateTarget.transform.position, rotationMask, rotationSpeed * Time.deltaTime);
            }
        }
    }
}