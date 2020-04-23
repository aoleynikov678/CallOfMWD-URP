using System.Collections.Generic;
using lab.core;
using UnityEngine;

namespace lab.mwd
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Lab/GameSettings")]
    public class GameSettings : InitSettings<GameSettings>
    {
        [SerializeField] private NetworkSettings networkSettings;

        public NetworkSettings NetworkSettings => networkSettings;

        // TODO move it
        public List<LevelReference> levels = new List<LevelReference>();
    }
}