using System;

namespace lab.ui
{
    public class UIParamAttribute : Attribute
    {
        public UIType UIType;
        public string Header;
        public string Description;
    }
}