using UnityEngine;

namespace lab.mwd
{
    public class PlayerService : IPlayerService
    {
        public PlayerService()
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject.DontDestroyOnLoad(player);
        }
    }
}