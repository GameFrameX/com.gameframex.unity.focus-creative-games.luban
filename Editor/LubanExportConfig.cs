using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using Debug = UnityEngine.Debug;

// using FilePathAttribute = Sirenix.OdinInspector.FilePathAttribute;

namespace Luban.Editor
{
    [CreateAssetMenu(fileName = "Luban", menuName = "Luban/ExportConfig")]
    public class LubanExportConfig : ScriptableObject
    {
        #region 必要参数

        /// <summary>
        /// Luban.conf 配置文件路径
        /// </summary>
        [HideInInspector] public string LuBanConfigPath = "../Config/Luban.conf";

        #endregion


        #region 其他

        [TextArea(5, 15)] [HideInInspector] public string preview_command;

        #endregion

        public void Gen()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileInfo luBanFileInfo = new FileInfo(LuBanConfigPath);
            if (!luBanFileInfo.Exists)
            {
                Debug.LogError("LuBan.conf 不存在");
                return;
            }

            var content = File.ReadAllText(luBanFileInfo.FullName);
            LuBanConfig config = JsonUtility.FromJson<LuBanConfig>(content);

            if (string.IsNullOrWhiteSpace(config.UNITY_ASSETS_PATH))
            {
                config.UNITY_ASSETS_PATH = Application.dataPath + "/";
            }

            if (string.IsNullOrWhiteSpace(config.SERVER_PATH))
            {
                config.SERVER_PATH = GenUtils.GetProjectPath + "/../Server/";
            }

            foreach (var command in config.commands)
            {
                if (command.active)
                {
                    if (string.IsNullOrEmpty(command.localizationFileName))
                    {
                        // 服务器
                    }
                    else
                    {
                        // 客户端
                        command.command += " -x l10n.provider=default -x l10n.textFile.keyFieldName=key ";
                        command.command += $" -x l10n.textFile.path={luBanFileInfo.Directory.FullName}/{config.dataDir}/{command.localizationFileName.Replace('\\', '/')}";
                    }

                    if (command.command.IndexOf("--conf", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        // 有配置
                    }
                    else
                    {
                        command.command += " --conf " + luBanFileInfo.FullName;
                    }

                    var commandLine = $"{GenUtils._DOTNET} {GenUtils.GetProjectPath}{config.toolPath} {command.command}";
                    commandLine = commandLine.Replace("%SERVER_PATH%", config.SERVER_PATH).Replace("%UNITY_ASSETS_PATH%", config.UNITY_ASSETS_PATH);

                    Debug.Log("开始导出:" + command.target);
                    GenUtils.Gen(commandLine, GenUtils.GetProjectPath);
                    Debug.Log("结束导出:" + command.target);
                }
            }

            stopwatch.Stop();
            Debug.Log($" 配置表导出结束！！！耗时:{stopwatch.ElapsedMilliseconds}毫秒");
        }

        /// <summary>
        /// 生成配置表
        /// </summary>
        [MenuItem("Tools/LuBan Config/Export &G")]
        public static void AutoGenClient()
        {
            CreateInstance<LubanExportConfig>()?.Gen();
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

        public void Preview()
        {
            // preview_command = $"{GenUtils._DOTNET} {_GetCommand()}";
        }
    }
}