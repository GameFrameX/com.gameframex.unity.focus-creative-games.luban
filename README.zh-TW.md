<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Luban 配置表組件

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## 項目簡介

非常強大的配置表解決方案。Luban 是一個強大、易用、優雅、穩定的遊戲配置解決方案。它設計目標為滿足從小型到超大型遊戲專案的簡單到複雜的遊戲配置工作流需求。

Luban 可以處理豐富的檔案類型，支援主流的語言，可以產生多種匯出格式，支援豐富的資料檢驗功能，具有良好的跨平台能力，並且產生極快。Luban 有清晰優雅的產生管線設計，支援良好的模組化和外掛能力，方便開發者進行二次開發。開發者很容易就能將 Luban 適配到自己的配置格式，定制出滿足專案要求的強大的配置工具。

Luban 標準化了遊戲配置開發工作流，可以極大提升策劃和程式的工作效率。

此函式庫主要服務於 [GameFrameX](https://github.com/GameFrameX/GameFrameX) 作為子庫使用。

### 改動功能

1. 新增 `Packages` 的支援
2. 移除 ODIN 的依賴
3. 新增防裁剪的輔助類別。需要在啟動的主場景中掛載 `LuBanCroppingHelper` 腳本即可

## 快速開始

### 安裝方式（任選其一）

1. 直接在 `manifest.json` 的 `dependencies` 節點下新增以下內容：
   ```json
   {
      "com.gameframex.unity.focus-creative-games.luban": "https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git"
   }
   ```
2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式新增庫，地址為：`https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git`
3. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

## 文檔與資源

- [Luban 使用文檔](https://luban.doc.code-philosophy.com/docs/intro)
- [GameFrameX 文檔](https://gameframex.doc.alianblank.com)

## 社區與支援

- QQ群: 467608841 / 233840761

## 更新日誌

查看 [Releases](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/releases) 了解更新日誌。

## 開源協議

本專案基於 [LICENSE.md](LICENSE.md) 中描述的協議開源。
