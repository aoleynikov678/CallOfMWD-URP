using System;
using UnityEngine.Events;

namespace lab.ui
{
    [Serializable]
    public class SelectorEvent : UnityEvent<string, int> {}
}