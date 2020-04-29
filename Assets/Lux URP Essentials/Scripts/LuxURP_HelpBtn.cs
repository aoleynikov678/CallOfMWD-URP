using UnityEngine;
using System.Collections;
#if UNITY_EDITOR

#endif

namespace LuxURPEssentials
{
    public class LuxURP_HelpBtn : PropertyAttribute
    {
        public string URL;
        public LuxURP_HelpBtn(string URL) {
            this.URL = URL;
        }
    }

#if UNITY_EDITOR
#endif
}