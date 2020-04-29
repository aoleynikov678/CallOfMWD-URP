using UnityEngine;

namespace lab.mwd
{
    public class CameraOffset : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationMask;
        [SerializeField] private Transform rotateTarget;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float tilt;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= new Vector3(0, 0.05f, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0.05f, 0);
            }
            
            Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
            transform.RotateAround(rotateTarget.transform.position, rotationMask, rotation.x * Time.deltaTime);
            
            // float rotation = Input.GetAxis("Mouse Y");
            // tilt = Mathf.Clamp(tilt - rotation, -15f, 15f);
            // transform.localRotation = Quaternion.Euler(tilt, 0, 0);
            
            // else if (Input.GetKey(KeyCode.LeftArrow))
            // {
            //     transform.RotateAround(rotateTarget.transform.position, rotationMask, -rotationSpeed * Time.deltaTime);
            // }
            // else if (Input.GetKey(KeyCode.RightArrow))
            // {
            //     transform.RotateAround(rotateTarget.transform.position, rotationMask, rotationSpeed * Time.deltaTime);
            // }
        }
    }
}