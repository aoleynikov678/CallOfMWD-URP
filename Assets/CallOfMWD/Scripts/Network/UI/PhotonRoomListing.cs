using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace lab.mwd
{
    public class PhotonRoomListing : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform contentParent;
        [SerializeField] private RoomEntry roomEntry;
        
        private List<RoomEntry> cachedRooms = new List<RoomEntry>();

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            foreach (var roomInfo in roomList)
            {
                if (roomInfo.RemovedFromList)
                {
                    int index = cachedRooms.FindIndex(x => x.RoomInfo.Name == roomInfo.Name);
                    if (index != -1)
                    {
                        Destroy(cachedRooms[index].gameObject);
                        cachedRooms.RemoveAt(index);
                    }
                }
                else
                {
                    var entry = Instantiate(roomEntry, contentParent);
                    entry.SetRoomInfo(roomInfo);
                    cachedRooms.Add(entry);
                }
            }
        }
    }
}