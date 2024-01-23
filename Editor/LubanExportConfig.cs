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

        /// <summary>
        /// DLL 路径
        /// </summary>
        [HideInInspector] public string which_dll = "./Tools~/Luban.dll";

        /// <summary>
        /// 自定义模版路径
        /// </summary>
        [HideInInspector] [Command("--customTemplateDir ", false)]
        public string TemplatePath = "./../Templates~";

        /// <summary>
        /// Luban.conf 配置文件路径
        /// </summary>
        [Command("--conf ")] [HideInInspector] public string LuBanConfigPath = "./Config/Luban.conf";

        /// <summary>
        /// 导出的数据类型
        /// </summary>
        [Command("--dataTarget ")] [HideInInspector]
        public DataTargetType dataTarget;

        /// <summary>
        /// 导出的代码类型
        /// </summary>
        [Command("--codeTarget ")] [HideInInspector]
        public CodeTargetType codeTarget;

        [Command("--target ")] [Tooltip("一般为 server, client 等")] [HideInInspector]
        public TargetName service;

        #endregion

        #region 输出配置

        [Command("--xargs outputDataDir=")] [HideInInspector]
        public string output_data_dir = "./../../../Assets/Bundles/Config";

        [Command("--xargs outputCodeDir=")] [HideInInspector]
        public string output_code_dir = "./../../../Assets/Hotfix/Config/Generate";

        #endregion

        [Command("--timeZone ")] [HideInInspector]
        public string timeZone = "Asia/Shanghai";

        [Command("--validationFailAsError ")] [HideInInspector]
        public string validationFailAsError = "";

        #region I10N

        /// <summary>
        /// 多语言输出文件路径
        /// </summary>
        [Command("--xargs l10n.textListFile=")] [HideInInspector]
        public string i10n_output_text_file;

        /// <summary>
        /// 多语言输入文件
        /// </summary>
        [Command("--xargs l10n.textProviderFile=")] [HideInInspector]
        public string i10n_input_text_file;

        #endregion

        #region 其他

        [TextArea(5, 15)] [HideInInspector] public string preview_command;

        #endregion

        public void Gen()
        {
            Preview();
            GenUtils.Gen(_GetCommand(), Application.dataPath);
        }

        private void Generator(bool isServer)
        {
            if (isServer)
            {
                service = TargetName.server;
                codeTarget = CodeTargetType.cs_dotnet_json;
                dataTarget = DataTargetType.json;
                output_code_dir = "../Server/Server.Config/Config";
                output_data_dir = "../Server/Server.Config/Json";
            }
            else
            {
                service = TargetName.client;
                codeTarget = CodeTargetType.cs_simple_json;
                dataTarget = DataTargetType.json;
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


        /// <summary>
        /// 获取LuBan工作路径
        /// </summary>
        /// <returns></returns>
        private string GetLuBanWorkPath()
        {
            var fromScriptableObject = MonoScript.FromScriptableObject(this);
            var assetPath = AssetDatabase.GetAssetPath(fromScriptableObject);
            DirectoryInfo directoryInfo = new DirectoryInfo(assetPath);
            return directoryInfo.Parent.Parent.FullName;
        }

        // [Button("预览")]
        public void Preview()
        {
            preview_command = $"{GenUtils._DOTNET} {_GetCommand()}";
        }

        private string _GetCommand()
        {
            string luBanWorkPath = GetLuBanWorkPath();
            which_dll = luBanWorkPath + "/Tools~/Luban.dll";
            TemplatePath = luBanWorkPath + "/Templates~";
            LuBanConfigPath = GenUtils.GetProjectPath + "/../Config/Luban.conf";
            string lineEnd = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".bat" : ".sh";

            StringBuilder sb = new StringBuilder();

            var fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            sb.Append(which_dll);

            foreach (var fieldInfo in fields)
            {
                var command = fieldInfo.GetCustomAttribute<CommandAttribute>();

                if (command is null)
                {
                    continue;
                }

                var value = fieldInfo.GetValue(this)?.ToString();


                // 当前值为空 或者 False, 或者 None(Enum 默认值)
                // 则继续循环
                if (string.IsNullOrEmpty(value) || string.Equals(value, "False") || string.Equals(value, "None"))
                {
                    continue;
                }

                if (fieldInfo.FieldType == typeof(CodeTargetType) || fieldInfo.FieldType == typeof(DataTargetType))
                {
                    value = value.Replace("_", "-");
                }

                if (string.Equals(value, "True"))
                {
                    value = string.Empty;
                }

                value = value.Replace(", ", ",");

                sb.Append($" {command.Option}{value} ");
            }

            return sb.ToString();
        }
    }
}