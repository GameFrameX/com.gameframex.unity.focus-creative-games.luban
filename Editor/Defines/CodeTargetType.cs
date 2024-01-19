using System;

namespace Luban.Editor
{
    /// <summary>
    /// Code Target Type 生成的代码目标
    /// </summary>
    public enum CodeTargetType
    {
        None = 0,

        /// <summary>
        /// C#，读取bin格式文件
        /// </summary>
        cs_bin,

        /// <summary>
        /// C#，使用System.Text.Json库读取json文件，推荐用于dotnet core服务器
        /// </summary>
        // [LabelText("C# dotnet Json 代码")]
        cs_dotnet_json,

        /// <summary>
        /// C#，使用SimpleJSON读取json文件，推荐用于Unity客户端
        /// </summary>
        // [LabelText("C# Unity Json 代码")]
        cs_simple_json,

        /// <summary>
        /// C#，读取与保存记录为单个json文件，适用于自定义编辑器保存与加载原始配置文件
        /// </summary>
        cs_editor_json,

        /// <summary>
        /// lua，读取lua格式的文件
        /// </summary>
        lua_lua,

        /// <summary>
        /// lua，读取bin格式文件
        /// </summary>
        lua_bin,

        /// <summary>
        /// java，读取bin格式文件
        /// </summary>
        java_bin,

        /// <summary>
        /// java，使用gson库读取json格式文件
        /// </summary>
        java_json,

        /// <summary>
        /// cpp，读取bin格式文件
        /// </summary>
        cpp_bin,

        /// <summary>
        /// go，读取bin格式文件
        /// </summary>
        go_bin,

        /// <summary>
        /// go，读取json格式文件
        /// </summary>
        go_json,

        /// <summary>
        /// python，读取json格式文件
        /// </summary>
        python_json,

        /// <summary>
        /// gdscript，读取json格式文件。注意，如果你使用C#语言开发，推荐使用更高效的cs-bin格式
        /// </summary>
        gdscript_json,

        /// <summary>
        /// typescript，读取json格式文件
        /// </summary>
        typescript_json,

        /// <summary>
        /// 生成proto2语法的schema文件
        /// </summary>
        protobuf2,

        /// <summary>
        /// 生成proto3语法的schema文件
        /// </summary>
        protobuf3,

        /// <summary>
        /// 生成flatbuffers的schema文件
        /// </summary>
        flatbuffers,
    }
}