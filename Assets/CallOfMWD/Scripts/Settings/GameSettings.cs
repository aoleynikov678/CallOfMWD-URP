using System.Collections.Generic;
using lab.core;
using UnityEngine;

namespace lab.mwd
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
    public class GameSettings : InitSettings
    {
        public List<LevelReference> levels = new List<LevelReference>();
    }
}