<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Luban コンフィグコンポーネント

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.focus-creative-games.luban)](https://github.com/GameFrameX/com.gameframex.unity.focus-creative-games.luban/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

## プロジェクト概要

非常に強力なコンフィグソリューション。Luban は強力で使いやすく、エレガントで安定したゲームコンフィグソリューションです。小規模から超大規模なゲームプロジェクトまで、シンプルから複雑なゲームコンフィグワークフローのニーズを満たすように設計されています。

Luban は豊富なファイルタイプを処理でき、主要な言語をサポートし、複数のエクスポート形式を生成し、豊富なデータ検証機能をサポートし、優れたクロスプラットフォーム機能を持ち、非常に高速に生成されます。Luban は明確でエレガントな生成パイプライン設計を持ち、優れたモジュール化とプラグイン機能をサポートし、開発者がカスタマイズしやすくなっています。

Luban はゲームコンフィグ開発ワークフローを標準化し、プランナーとプログラマーの作業効率を大幅に向上させます。

このライブラリは主に [GameFrameX](https://github.com/GameFrameX/GameFrameX) のサブモジュールとして使用されます。

### 公式版からの変更点

1. Unity Package Manager サポートの追加
2. ODIN 依存関係の削除
3. アンチストリッピングヘルパークラスの追加。起動時のメインシーンに `LuBanCroppingHelper` スクリプトをマウントする必要があります。

## クイックスタート

### インストール

以下のいずれかの方法を選択してください：

1. Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：
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

   `scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

2. `manifest.json` の `dependencies` に直接追加：
   ```json
   {
      "com.gameframex.unity.focus-creative-games.luban": "https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git"
   }
   ```
3. Unity の **Package Manager** で **Git URL** を使用して追加：`https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git`
4. リポジトリを Unity プロジェクトの `Packages` ディレクトリにクローンしてください。自動的に読み込まれます。
## ドキュメントとリソース

- [Luban ドキュメント](https://luban.doc.code-philosophy.com/docs/intro)
- [GameFrameX ドキュメント](https://gameframex.doc.alianblank.com)

## コミュニティとサポート

- QQグループ: 467608841 / 233840761

## 変更履歴

変更履歴は [Releases](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/releases) をご覧ください。


## 依存関係

| パッケージ | 説明 |
|----------|------|
| (无) | - |

## ライセンス

このプロジェクトは [LICENSE.md](LICENSE.md) に記載されている条件で公開されています。
