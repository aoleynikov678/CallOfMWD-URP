using UnityEditor;
using UnityEngine;

namespace lab.ui
{
    [CustomEditor(typeof(LabUIGenerator))]
    public class LabUIGeneratorEditor : Editor
    {
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            LabUIGenerator generator = (LabUIGenerator)target;
            
            if (GUILayout.Button("Создать элемент"))
            {
                generator.GenerateFakeElement();
            }
            
            EditorGUILayout.Space();
           
            if (GUILayout.Button("Создать UI"))
            {
                generator.GenerateUI();
            }
        }
    }
}