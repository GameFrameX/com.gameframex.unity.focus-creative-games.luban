using System;

// using Sirenix.OdinInspector;

namespace Luban.Editor
{
    [Flags]
    public enum GenTypes
    {
        None = 0,

        /// <summary>
        /// C# 二进制代码
        /// </summary>
        // [LabelText("C# 二进制代码")]
        cs_bin = 1,

        /// <summary>
        /// C# dotnet Json 代码
        /// </summary>
        // [LabelText("C# dotnet Json 代码")]
        cs_dotnet_json = cs_bin << 1,

        /// <summary>
        /// C# Unity Json 代码
        /// </summary>
        // [LabelText("C# Unity Json 代码")]
        cs_simple_json = cs_dotnet_json << 1,

        /// <summary>
        /// C# Unity Editor Json 代码
        /// </summary>
        // [LabelText("C# Unity Editor Json 代码")]
        cs_editor_json = cs_simple_json << 1,

        /// <summary>
        /// lua 二进制代码
        /// </summary>
        // [LabelText("lua 二进制代码")]
        lua_bin = cs_editor_json << 1,

        /// <summary>
        /// TS 二进制代码
        /// </summary>
        // [LabelText("TS 二进制代码")]
        typescript_json = lua_bin << 1,

        /// <summary>
        /// 二进制数据
        /// </summary>
        // [LabelText("二进制数据")]
        data_bin = typescript_json << 1,

        /// <summary>
        /// 二进制 Lua 数据
        /// </summary>
        // [LabelText("二进制 Lua 数据")]
        lua_lua = data_bin << 1,
    }
}