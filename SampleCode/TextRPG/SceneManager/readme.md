# 🔎 SceneManager
게임의 메인 단위인 Scene과 Scene을 관리하는 SceneManager 클래스 코드입니다.



<!--![이미지]()-->

<br>

## 🎞 코드 

| Script명 | 설명 |
|---|---|
|[SceneManager.cs](./SceneManager.cs) | Scene의 정보를 Dictionary 형태로 보관하는 클래스 입니다. <br> C# 리플렉션을 활용해 Scene의 파생클래스를 가져오는 기능이 구현된 클래스입니다. |
|[Scene.cs](./Scene.cs)| 컴포짓 패턴에 맞추어 구성된 부모 클래스로 다양한 파생클래스에서<br> 각 상황에 맞는 구현을 하도록 구성하여 일관된 Scene 구조를 구성하도록 돕는 클래스입니다. |
|[MainScene.cs](./MainScene.cs)| 게임의 메인 화면을 보여주는 클래스 |
|[BattleScene.cs](./BattleScene.cs)| 배틀 시작 화면을 보여주는 클래스 |
|[InventoryScene.cs](./InventoryScene.cs)| 인벤토리의 화면을 보여주는 클래스 |


## [⏮ 돌아가기](../../)
