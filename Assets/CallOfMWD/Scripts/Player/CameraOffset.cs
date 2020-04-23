using UnityEngine;

namespace lab.mwd
{
    public class CameraOffset : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position -= new Vector3(0, 0.1f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0.1f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, -10, 0));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, 10, 0));
            }
        }
    }
}