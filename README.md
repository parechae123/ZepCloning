## 목차
  - [개요](#개요) 
  - [게임 설명](#게임-설명)
  - [게임 플레이 방식](#게임-플레이-방식)

## 개요
- Repository : ZepCloning
- 프로젝트 작업 기간 : 2025.07.22-2025.07.28
- 개발 엔진 및 언어: Unity & C#
- 사용 라이브러리 : Unity,Newtonsoft.Json
## 게임 플레이 방식
- 캐릭터 이동 방법

|이동방향|상(위)|좌(왼쪽)|하(아래)|우(오른쪽)|
|---|---|---|---|---|
|키보드| W | A | S | D |
- 캐릭터 인터렉션 키

||인터렉션 키|
|---|---|
|키보드| SpaceBar |

||플로피 점프 키|
|---|---|
|키보드| SpaceBar |


- 카메라 이동제약
   - 4방향 중 충돌하는 오브젝트가 없으면 카메라의 이동을 제약
   - 스크립트 : ZepCam.cs