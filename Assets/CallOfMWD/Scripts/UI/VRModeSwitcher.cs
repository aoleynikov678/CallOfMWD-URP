using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace lab.mwd
{
    public class VRModeSwitcher : MonoBehaviour
    {
        [SerializeField] private Button vrMode;
        [SerializeField] private Button wasdMode;

        public event Action OnVR;
        public event Action OnWASD;
        
        private void Awake()
        {

        }
    }

}