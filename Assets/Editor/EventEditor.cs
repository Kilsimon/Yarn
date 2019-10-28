using UnityEditor;
using UnityEngine;
using BrokenWindow.Events;

namespace BrokenWindow.Editors
{
    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUI.enabled = Application.isPlaying;
            GameEvent e = target as GameEvent;
            EditorGUILayout.LabelField(GUI.enabled ? "Debugging" : "Debugging (Game must be running)");
            if (GUILayout.Button("DEBUG Raise"))
            {
                e.Raise();
            }
        }
    }
}