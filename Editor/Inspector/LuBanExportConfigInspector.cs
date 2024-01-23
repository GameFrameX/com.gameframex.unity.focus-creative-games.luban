using UnityEditor;
using UnityEngine;

namespace Luban.Editor
{
    [CustomEditor(typeof(LubanExportConfig))]
    public class LuBanExportConfigInspector : UnityEditor.Editor
    {
        private SerializedProperty m_tpl_path;
        private SerializedProperty m_output_code_dir;
        private SerializedProperty m_output_data_dir;
        private SerializedProperty m_preview_command;
        private SerializedProperty m_job;
        private SerializedProperty m_codeTarget;
        private SerializedProperty m_dataTarget;
        private SerializedProperty m_service;
        private SerializedProperty m_timezone;
        private SerializedProperty m_i10n_output_text_file;
        private SerializedProperty m_i10n_input_text_file;

        private void OnEnable()
        {
            m_tpl_path = serializedObject.FindProperty("TemplatePath");
            m_job = serializedObject.FindProperty("LuBanConfigPath");
            m_codeTarget = serializedObject.FindProperty("codeTarget");
            m_dataTarget = serializedObject.FindProperty("dataTarget");
            m_service = serializedObject.FindProperty("service");

            m_output_data_dir = serializedObject.FindProperty("output_data_dir");
            m_output_code_dir = serializedObject.FindProperty("output_code_dir");

            m_timezone = serializedObject.FindProperty("timeZone");
            m_i10n_output_text_file = serializedObject.FindProperty("i10n_output_text_file");
            m_i10n_input_text_file = serializedObject.FindProperty("i10n_input_text_file");


            m_preview_command = serializedObject.FindProperty("preview_command");
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var config = (LubanExportConfig)target;

            EditorGUILayout.PropertyField(m_tpl_path, new GUIContent("模板路径"));
            EditorGUILayout.PropertyField(m_job, new GUIContent("LuBan.conf 路径"));
            // EditorGUILayout.PropertyField(m_define_xml, new GUIContent("定义XML"));
            EditorGUILayout.PropertyField(m_codeTarget, new GUIContent("代码生成类型"));
            EditorGUILayout.PropertyField(m_dataTarget, new GUIContent("数据生成类型"));
            EditorGUILayout.PropertyField(m_service, new GUIContent("导出数据类型"));

            EditorGUILayout.PropertyField(m_output_data_dir, new GUIContent("输出数据文件夹"));
            EditorGUILayout.PropertyField(m_output_code_dir, new GUIContent("输出代码文件夹"));

            EditorGUILayout.PropertyField(m_timezone, new GUIContent("时区"));
            EditorGUILayout.PropertyField(m_i10n_input_text_file, new GUIContent("多语言输入文件"));
            EditorGUILayout.PropertyField(m_i10n_output_text_file, new GUIContent("多语言文本输出文件"));

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