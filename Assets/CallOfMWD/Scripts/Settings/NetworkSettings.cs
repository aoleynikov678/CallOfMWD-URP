using lab.ui;
using UnityEngine;

namespace lab.mwd
{
    [CreateAssetMenu(fileName = "NetworkSettings", menuName = "Lab/NetworkSettings")]
    public class NetworkSettings : ScriptableObject
    {
        [UIParam(UIType = UIType.Input, Header = "Имя", Description = "Имя пользователя")]
        [SerializeField] private string nickName;
        
        [UIParam(UIType = UIType.Selector, Header = "Роль", Description = "Сетевая роль")]
        [SerializeField] private NetworkRole networkRole;

        public string NickName => nickName;
        public NetworkRole NetworkRole => networkRole;
    }
}