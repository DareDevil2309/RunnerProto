using DefaultNamespace;
using UnityEditor;
using UnityEngine;

namespace GameEditor.Scripts
{
    [CustomEditor(typeof(Level))]
    public class LevelEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Generate path"))
            {
                (target as Level)?.GeneratePath();
            }
            
            if (GUILayout.Button("Generate buildings"))
            {
                (target as Level)?.GenerateBuildings();
            }
        }
    }
}