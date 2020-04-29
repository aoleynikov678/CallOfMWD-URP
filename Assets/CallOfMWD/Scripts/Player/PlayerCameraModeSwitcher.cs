using UnityEngine;
using XRController = UnityEngine.XR.Interaction.Toolkit.XRController;

namespace lab.mwd
{
    public class PlayerCameraModeSwitcher
    {
        private Camera mainCamera;
        private XRController headController;
        private float fovVR;
        
        public PlayerCameraModeSwitcher(Camera cam)
        {
            mainCamera = cam;
            fovVR = mainCamera.fieldOfView;
            headController = mainCamera.GetComponent<XRController>();
        }

        public void SetToVR()
        {
            mainCamera.stereoTargetEye = StereoTargetEyeMask.Both;
            mainCamera.fieldOfView = fovVR;
            headController.enabled = true;
        }

        public void SetToDisplay()
        {
            mainCamera.stereoTargetEye = StereoTargetEyeMask.None;
            mainCamera.fieldOfView = 60;
            headController.enabled = false;
        }
    }
}