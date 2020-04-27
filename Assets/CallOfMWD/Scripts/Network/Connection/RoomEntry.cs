using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace lab.mwd
{
    public class RoomEntry : MonoBehaviour
    {
        [SerializeField] private TMP_Text roomName;

        public RoomInfo RoomInfo { get; private set; }

        public void SetRoomInfo(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            roomName.text = roomInfo.Name;
        }
    }
}