namespace Luban.Editor
{
    /// <summary>
    /// 数据目标类型
    /// </summary>
    public enum DataTargetType
    {
        /// <summary>
        /// Luban独有的binary格式，紧凑、高效，推荐用于正式发布
        /// </summary>
        bin,

        /// <summary>
        /// 记录以bin格式导出的数据文件中每个记录的索引位置，可以用于以记录为粒度的lazy加载
        /// </summary>
        bin_offset,

        /// <summary>
        /// json格式
        /// </summary>
        json,

        /// <summary>
        /// lua格式
        /// </summary>
        lua,

        /// <summary>
        /// xml格式
        /// </summary>
        xml,

        /// <summary>
        /// yaml格式
        /// </summary>
        yml,

        /// <summary>
        /// bson格式
        /// </summary>
        bson,

        /// <summary>
        /// msgpack的二进制格式
        /// </summary>
        msgpack,

        /// <summary>
        /// protobuf的二进制格式
        /// </summary>
        protobuf_bin,

        /// <summary>
        /// protobuf3起支持的json格式
        /// </summary>
        protobuf_json,

        /// <summary>
        /// flatbuffers支持的json格式
        /// </summary>
        flatbuffers_json,

        /// <summary>
        /// 输出配置出现的所有text key，按从小到大排序
        /// </summary>
        text_list,
    }
}