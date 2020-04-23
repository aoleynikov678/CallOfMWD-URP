using Photon.Pun;

namespace lab.mwd
{
    public class LocalPlayer : MonoBehaviourPun
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}