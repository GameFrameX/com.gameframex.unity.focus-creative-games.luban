<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Luban Config Component

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

A powerful game configuration solution. Luban is a powerful, easy-to-use, elegant, and stable game configuration solution designed to meet the workflow needs of game configuration from small to very large game projects.

Luban can handle rich file types, supports mainstream languages, generates multiple export formats, supports rich data validation, has good cross-platform capability, and generates extremely fast. Luban has a clear and elegant generation pipeline design, supports good modularization and plugin capabilities, making it easy for developers to customize and adapt Luban to their own configuration formats.

Luban standardizes the game configuration development workflow, greatly improving the efficiency of designers and programmers.

This library primarily serves as a sub-module for [GameFrameX](https://github.com/GameFrameX/GameFrameX).

### Modifications from Official Version

1. Added Unity Package Manager support
2. Removed ODIN dependency
3. Added anti-stripping helper class. Mount the `LuBanCroppingHelper` script on the main startup scene.

## Quick Start

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
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
     ],
     "dependencies": {
       "com.gameframex.unity.focus-creative-games.luban": "2.1.2"
     }
   }
   ```

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.focus-creative-games.luban": "https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.
## Documentation & Resources

- [Luban Documentation](https://luban.doc.code-philosophy.com/docs/intro)
- [GameFrameX Documentation](https://gameframex.doc.alianblank.com)

## Community & Support

- QQ Group: 467608841 / 233840761

## Changelog

See [Releases](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/releases) for changelog.


## Dependencies

| Package | Description |
|---------|-------------|
| (无) | - |

## License

This project is open-sourced under the terms described in [LICENSE.md](LICENSE.md).
