using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Luban.Editor
{
    [Serializable]
    public class LuBanConfig
    {
        /// <summary>
        /// LuBan 路径
        /// </summary>
        [SerializeField] public string toolPath;

        /// <summary>
        /// 数据文件夹
        /// </summary>
        [SerializeField] public string dataDir;

        /// <summary>
        /// Unity Assets 全路径
        /// </summary>
        [SerializeField] public string UNITY_ASSETS_PATH;

        /// <summary>
        /// 服务端全路径
        /// </summary>
        [SerializeField] public string SERVER_PATH;

        /// <summary>
        /// 命令
        /// </summary>
        [SerializeField] public List<LuBanConfigCommand> commands = new List<LuBanConfigCommand>();
    }

    [Serializable]
    public class LuBanConfigCommand
    {
        /// <summary>
        /// 导出目标
        /// </summary>
        [SerializeField] public string target;

        /// <summary>
        /// 命令
        /// </summary>
        [SerializeField] public string command;

        /// <summary>
        /// 本地化导出文件
        /// </summary>
        [SerializeField] public string localizationFileName;

        /// <summary>
        /// 是否激活
        /// </summary>
        [SerializeField] public bool active;
    }
}