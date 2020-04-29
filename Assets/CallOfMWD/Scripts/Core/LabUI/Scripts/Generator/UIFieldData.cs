using System.Reflection;

namespace lab.ui
{
    public class UIFieldData
    {
        public UIParamAttribute UIAttribute;
        public FieldInfo FieldInfo;
        public UnityEngine.Object FieldSource;

        public UIFieldData(UIParamAttribute uiAttribute, FieldInfo fieldInfo, UnityEngine.Object fieldSource)
        {
            UIAttribute = uiAttribute;
            FieldInfo = fieldInfo;
            FieldSource = fieldSource;
        }
    }
}