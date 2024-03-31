using UnityEditor;
using UnityEngine;

namespace Luban.Editor
{
    [CustomEditor(typeof(LubanExportConfig))]
    public class LuBanExportConfigInspector : UnityEditor.Editor
    {
        private SerializedProperty m_preview_command;
        private SerializedProperty m_job;

        private void OnEnable()
        {
            m_job = serializedObject.FindProperty("LuBanConfigPath");
            m_preview_command = serializedObject.FindProperty("preview_command");
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var config = (LubanExportConfig)target;

            EditorGUILayout.PropertyField(m_job, new GUIContent("LuBan.conf 路径"));

            EditorGUILayout.PropertyField(m_preview_command, new GUIContent("预览命令"));

            if (GUILayout.Button("生成"))
            {
                config.Gen();
            }

            if (GUILayout.Button("预览命令"))
            {
                config.Preview();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}