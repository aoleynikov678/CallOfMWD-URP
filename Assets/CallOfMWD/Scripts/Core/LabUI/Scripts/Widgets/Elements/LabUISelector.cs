using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
    public class LabUISelector : LabUIElementWithButtons<string>
    {
        [Header("Опции и описания")]
        
        [SerializeField] 
        private List<string> options = new List<string>();
        
        [SerializeField] 
        private List<string> descriptions = new List<string>();

        [SerializeField]
        public SelectorEvent OnValueChanged;

        private bool showDescriptionsByDefault = true;   
        private int curIndex = 0;

        public void ClearOptions()
        {
            options.Clear();
            text.text = "";
        }

        public void AddOption(string option)
        {
            this.options.Add(option);

            if (options.Count == 1)
            {
                SetValueByIndex(0);
            }
        }
        
        public void RemoveOption(string option)
        {
            this.options.Remove(option);
            
            SetValueByIndex(0);
        }
        
        public void SetOptions(List<string> options)
        {
            this.options = options;
            
            SetValueByIndex(0);
        }

        public void SetDescriptions(List<string> descriptions)
        {
            this.descriptions = descriptions;
        }

        public override void SetValue(string val)
        {
            curIndex = options.FindIndex(a => a == val);
            
            if (curIndex < 0 || curIndex >= options.Count)
            {
                curIndex = 0;
            }
            
            SetValueByIndex(curIndex);
        }
        
        public void SetValueByIndex(int index)
        {
            if (index < 0 || index >= options.Count)
            {
                index = 0;
            }

            if (options.Count == 0)
            {
                text.text = "";
            }
            else
            {

                if (showDescriptionsByDefault && descriptions.Count >= index && descriptions.Count > 0)
                {
                    text.text = descriptions[index];
                }
                else
                {
                    text.text = options[index];
                }

                OnValueChanged?.Invoke(options[index], index);
            }
        }

        protected override void OnNextPressed()
        {
            base.OnNextPressed();
            
            curIndex++;
            if (curIndex >= options.Count)
            {
                curIndex = 0;
            }

            SetValueByIndex(curIndex);
        }
        
        protected override void OnPrevPressed()
        {
            base.OnPrevPressed();
            
            curIndex--;
            if (curIndex < 0)
            {
                curIndex = options.Count - 1;
            }

            SetValueByIndex(curIndex);
        }
    }
}