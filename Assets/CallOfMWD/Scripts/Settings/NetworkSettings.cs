using UnityEngine;

namespace lab.mwd
{
    [CreateAssetMenu(fileName = "NetworkSettings", menuName = "Lab/NetworkSettings")]
    public class NetworkSettings : ScriptableObject
    {
        [SerializeField] private string nickName;

        public string NickName => nickName;
    }
}