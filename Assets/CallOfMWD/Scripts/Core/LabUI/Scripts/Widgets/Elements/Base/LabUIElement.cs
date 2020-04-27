using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace lab.ui
{
    public abstract class LabUIElement<T> : Selectable
    {
        [Header("Поле вывода данных")]
        [SerializeField] 
        protected TMP_Text text;
        
        [Header("Заголовки в UI")]
        
        [SerializeField]
        private TMP_Text header;
        [SerializeField]
        private TMP_Text headerDescription;
        
        //public bool Ready = false;
        //public UnityAction<T> OnValueChanged;
        public abstract void SetValue(T val);
        
        public virtual void SetHeader(string val)
        {
            header.text = val;
        }
        
        public virtual void SetHeaderDescription(string val)
        {
            headerDescription.text = val;
        }
    }
}