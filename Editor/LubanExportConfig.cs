using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
// using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

// using FilePathAttribute = Sirenix.OdinInspector.FilePathAttribute;

namespace Luban.Editor
{
    [CreateAssetMenu(fileName = "Luban", menuName = "Luban/ExportConfig")]
    public class LubanExportConfig : ScriptableObject
    {
        #region 必要参数

        [HideInInspector] public string which_dll = "./Tools~/Luban.dll";

        [HideInInspector] [Command("--customTemplateDir ", false)]
        public string tpl_path;

        [Command("--conf ")] [HideInInspector] public string job = "./Config/Luban.conf";

        [Command("--dataTarget ")] [HideInInspector]
        public GenTypes dataTarget;

        [Command("--codeTarget ")] [HideInInspector]
        public GenTypes codeTarget;

        [Command("--target ")] [Tooltip("一般为 server, client 等")] [HideInInspector]
        public TargetName service;

        #endregion

        #region 输出配置

        [Command("--xargs outputDataDir=")] [HideInInspector]
        public string output_data_dir;

        [Command("--xargs outputCodeDir=")] [HideInInspector]
        public string output_code_dir;

        [Command("--output:data:resource_list_file")] [HideInInspector]
        public string output_data_resources_list_file;

        [Command("--output:exclude_tags")] [HideInInspector]
        public string output_exclude_tags;

        [Command("--output:data:file_extension")] [HideInInspector]
        public string output_data_file_extension;

        [Command("--output:data:compact_json")] [HideInInspector]
        public bool output_data_compact_json;

        [Command("--output:data:json_monolithic_file")] [HideInInspector]
        public string output_data_json_monolithic_file;

        #endregion

        #region I10N

        [Command("--l10n:timezone")] [HideInInspector]
        public string i10n_timezone;

        [Command("--l10n:input_text_files")] [HideInInspector]
        public string i10n_input_text_files;

        [Command("--l10n:text_field_name")] [HideInInspector]
        public string i10n_text_field_name;

        [Command("--l10n:output_not_translated_text_file")] [HideInInspector]
        public string i10n_output_not_translated_text_file;

        [Command("--l10n:patch")] [HideInInspector]
        public string i10n_path;

        [Command("--l10n:patch_input_data_dir")] [HideInInspector]
        public string i10n_patch_input_data_dir;

        #endregion

        #region 其他

        [TextArea(5, 15)] 
        [HideInInspector] 
        public string preview_command;

        #endregion

        public void Gen()
        {
            Preview();
            GenUtils.Gen(_GetCommand());
        }

        private void Generator(bool isServer)
        {
            if (isServer)
            {
                service = TargetName.server;
                codeTarget = GenTypes.cs_dotnet_json;
                output_code_dir = "../Server/Server.Config/Config";
                output_data_dir = "../Server/Server.Config/Json";
            }
            else
            {
                service = TargetName.client;
                codeTarget = GenTypes.cs_simple_json;
                output_code_dir = "Assets/Hotfix/Config/Generate";
                output_data_dir = "Assets/Bundles/Config";
            }

            Preview();
            GenUtils.Gen(_GetCommand());
        }

        /// <summary>
        /// 生成客户端
        /// </summary>
        [MenuItem("Tools/LuBan Config/Generator Client")]
        public static void AutoGenClient()
        {
            // var fromScriptableObject = MonoScript.FromScriptableObject(CreateInstance<LubanExportConfig>());
            // var assetPath = AssetDatabase.GetAssetPath(fromScriptableObject);
            //
            // Debug.Log(assetPath);

            CreateInstance<LubanExportConfig>()?.Generator(false);
        }

        /// <summary>
        /// 生成服务器
        /// </summary>
        [MenuItem("Tools/LuBan Config/Generator Server")]
        public static void AutoGenServer()
        {
            CreateInstance<LubanExportConfig>()?.Generator(true);
        }

        // [Button("删除")]
        public void Delete()
        {
            bool isExists = Directory.Exists(output_code_dir);
            if (isExists)
            {
                Directory.Delete(output_code_dir, true);
            }

            AssetDatabase.Refresh();
        }

        // [Button("预览")]
        public void Preview()
        {
            preview_command = $"{GenUtils._DOTNET} {_GetCommand()}";
        }

        private string _GetCommand()
        {
            var fromScriptableObject = MonoScript.FromScriptableObject(this);
            var assetPath = AssetDatabase.GetAssetPath(fromScriptableObject);
            DirectoryInfo directoryInfo = new DirectoryInfo(assetPath);
            tpl_path = directoryInfo.Parent.Parent + "/Templates";

            string lineEnd = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? " ^" : " \\";

            StringBuilder sb = new StringBuilder();

            var fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            sb.Append(which_dll);

            foreach (var field_info in fields)
            {
                var command = field_info.GetCustomAttribute<CommandAttribute>();

                if (command is null)
                {
                    continue;
                }

                var value = field_info.GetValue(this)?.ToString();

                // 当前值为空 或者 False, 或者 None(Enum 默认值)
                // 则继续循环
                if (string.IsNullOrEmpty(value) || string.Equals(value, "False") || string.Equals(value, "None"))
                {
                    continue;
                }


                if (string.Equals(value, "True"))
                {
                    value = string.Empty;
                }

                value = value.Replace(", ", ",");

                sb.Append($" {command.Option}{value} ");

                if (command.NewLine)
                {
                    sb.Append($"{lineEnd} \n");
                }
            }

            return sb.ToString();
        }
    }
}