using Photon.Pun;
using UnityEngine;

namespace lab.mwd
{
    public class LevelLoadTest : MonoBehaviourPun
    {
        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PhotonNetwork.LoadLevel("Test");
                }
            }
        }
    }
}