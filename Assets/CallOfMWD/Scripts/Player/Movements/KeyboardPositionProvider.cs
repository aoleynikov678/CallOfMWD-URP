using lab.core;
using UnityEngine;

namespace lab.mwd
{
    public class KeyboardPositionProvider : IPositionProvider
    {
        private IPlayerInputService playerInputService;
        public Transform Transform { get; private set; }

        private float speedH = 2.0f;
        private float speedV = 2.0f;

        private float yaw = 0.0f;
        private float pitch = 0.0f;
        
        public void Init(Transform parent, Camera mainCamera)
        {
            playerInputService = ServiceLocator.Current.Get<IPlayerInputService>();
            Transform = mainCamera.transform;

            var curPos = Transform.position;
            curPos.y = 2;
            Transform.position = curPos;
        }

        // TODO take data from playerInputService
        public void Tick()
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Transform.position -= new Vector3(0, 0.05f, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                Transform.position += new Vector3(0, 0.05f, 0);
            }

            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            
            Transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }

    }
}