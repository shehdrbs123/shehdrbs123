# 🔎 제작/건설 관련 UI

제작과 건설의 UI를 같은 Prefab을 사용하기 위해, 제작한 UI 클래스 코드모음입니다.


<!--![이미지]()-->

<br>

## 🎞 코드 

### 충돌 기능
| Script명 | 설명 |
|---|---|
|[GridPanelManager.cs](./GridPanelManager.cs)| 제작/건설 UI에 필요한 Interface를 가지고 있는 추상 클래스입니다.  |
|[GridPanelUI.cs](./GridPanelUI.cs)| 제작/건설 클래스의 부모 클래스로 현재 설정된 PanelType에 맞게 <br>UI 기본 설정을 수행하는 스크립트입니다.  |
|[GridButtonUI.cs](./GridButtonUI.cs)| 제작/건설 UIButton 에 필요한 기본적인 기능을 가지고 있는 클래스 입니다. |
|[BuildTargetButtonUI](./BuildTargetButtonUI.cs)| 건설할 건물을 선택, 버튼을 누르면 해당 오브젝트로 건설을 수행하도록 하는 스크립트 입니다. |
|[InfoUIFollower.cs](./InfoUIFollower.cs)| 마우스를 버튼위에 올리면 제작/건설 관련 정보 정보창UI 입니다. |


<br>

## [⏮ 돌아가기](../../)
