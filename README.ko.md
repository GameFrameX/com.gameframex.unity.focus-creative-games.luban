<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160"/>

# Game Frame X Luban 설정 컴포넌트

[![License](https://img.shields.io/github/license/gameframex/com.gameframex.unity.focus-creative-games.luban)](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/blob/main/LICENSE)
[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.focus-creative-games.luban)](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/releases)
[![Documentation](https://img.shields.io/badge/Documentation-문서-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5kbDVBdUeS) · **언어**

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

---

## 프로젝트 개요

매우 강력한 설정 솔루션. Luban은 강력하고 사용하기 쉬우며 우아하고 안정적인 게임 설정 솔루션입니다. 소규모에서 초대형 게임 프로젝트까지 간단한 것부터 복잡한 게임 설정 워크플로우 요구를 충족하도록 설계되었습니다.

Luban은 다양한 파일 유형을 처리할 수 있고, 주요 언어를 지원하며, 여러 내보내기 형식을 생성하고, 풍부한 데이터 검증 기능을 지원하며, 우수한 크로스 플랫폼 기능을 갖추고 있고 매우 빠르게 생성됩니다. Luban은 명확하고 우아한 생성 파이프라인 설계를 갖추고 있어 개발자가 자신의 설정 형식에 맞게 쉽게 커스터마이징할 수 있습니다.

Luban은 게임 설정 개발 워크플로우를 표준화하여 기획자와 프로그래머의 작업 효율성을 크게 향상시킵니다.

이 라이브러리는 주로 [GameFrameX](https://github.com/GameFrameX/GameFrameX)의 서브모듈로 사용됩니다.

### 공식 버전에서의 변경 사항

1. Unity Package Manager 지원 추가
2. ODIN 의존성 제거
3. 안티 스트리핑 헬퍼 클래스 추가. 시작 메인 씬에 `LuBanCroppingHelper` 스크립트를 마운트해야 합니다.

## 빠른 시작

### 설치 방법 (선택)

1. `manifest.json`의 `dependencies`에 다음 내용을 추가:
   ```json
   {
      "com.gameframex.unity.focus-creative-games.luban": "https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git"
   }
   ```
2. Unity의 `Packages Manager`에서 `Git URL`을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban.git`
3. 저장소를 직접 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치하면 자동으로 로드됩니다.

## 문서 및 자료

- [Luban 문서](https://luban.doc.code-philosophy.com/docs/intro)
- [GameFrameX 문서](https://gameframex.doc.alianblank.com)

## 커뮤니티 및 지원

- [QQ 그룹](https://qm.qq.com/q/5kbDVBdUeS)

## 변경 로그

변경 로그는 [Releases](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/releases)에서 확인하세요.

## 라이선스

이 프로젝트는 [MIT 라이선스](https://github.com/gameframex/com.gameframex.unity.focus-creative-games.luban/blob/main/LICENSE)에 따라 배포됩니다.
