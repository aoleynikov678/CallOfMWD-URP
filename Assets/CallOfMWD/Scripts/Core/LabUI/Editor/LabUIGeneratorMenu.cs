using UnityEditor;
using UnityEngine;

namespace lab.ui
{
    public class LabUIGeneratorMenu : MonoBehaviour
    {
        [MenuItem("Lab/UI/Create Generator")]
        private static void CreateGenerator()
        {
            var generatorPrefab = Resources.Load<LabUIGenerator>("UI Generator");

            var generator = Instantiate(generatorPrefab);
            generator.name = "UI Generator";
        }
    }
}