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
            
            if (GUILayout.Button("Generate"))
            {
                (target as Level)?.GenerateLevel();
            }
        }
    }
}