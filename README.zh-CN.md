<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Luban 配置表组件

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 项目简介

非常强大的配置表解决方案。Luban 是一个强大、易用、优雅、稳定的游戏配置解决方案。它设计目标为满足从小型到超大型游戏项目的简单到复杂的游戏配置工作流需求。

Luban 可以处理丰富的文件类型，支持主流的语言，可以生成多种导出格式，支持丰富的数据检验功能，具有良好的跨平台能力，并且生成极快。Luban 有清晰优雅的生成管线设计，支持良好的模块化和插件化，方便开发者进行二次开发。开发者很容易就能将 Luban 适配到自己的配置格式，定制出满足项目要求的强大的配置工具。

Luban 标准化了游戏配置开发工作流，可以极大提升策划和程序的工作效率。

该库主要服务于 [GameFrameX](https://github.com/GameFrameX/GameFrameX) 作为子库使用。

### 改动功能

1. 增加 `Packages` 的支持
2. 移除 ODIN 的依赖
3. 增加防裁剪的帮助类。需要在启动的主场景中挂载 `LuBanCroppingHelper` 脚本即可

## 快速开始

### 安装

编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ]
}
```

`scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.focus-creative-games.luban": "2.1.2"
  }
}
```

## 文档与资源

- [Luban 使用文档](https://luban.doc.code-philosophy.com/docs/intro)
- [GameFrameX 文档](https://gameframex.doc.alianblank.com)

## 社区与支持

- QQ群: 467608841 / 233840761

## 更新日志

查看 [Releases](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/releases) 了解更新日志。


## 依赖

| 包 | 说明 |
|----|------|
| (无) | - |

## 开源协议

详见 [LICENSE.md](LICENSE.md) 文件。
