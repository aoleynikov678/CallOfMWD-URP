using System.Collections.Generic;

namespace lab.ui
{
    public class LabUICheckbox : LabUIElementWithButtons<bool>
    {
        public CheckboxEvent OnValueChanged;
        
        private readonly Dictionary<bool, string> boolValToString = new Dictionary<bool, string>
        {
            {true, "ДА"},
            {false, "НЕТ"},
        };

        private bool curVal; 
        
        public override void SetValue(bool val)
        {
            text.text = boolValToString[val];
            curVal = val;
            OnValueChanged?.Invoke(val);
        }

        protected override void OnNextPressed()
        {
            base.OnNextPressed();
            curVal = !curVal;
            SetValue(curVal);
        }

        protected override void OnPrevPressed()
        {
            base.OnPrevPressed();
            curVal = !curVal;
            SetValue(curVal);
        }
    }
}