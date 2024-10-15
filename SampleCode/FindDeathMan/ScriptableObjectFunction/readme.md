# 🔎 기능 Scriptable Object

언리얼의 클래스 레퍼런스 기능을 유니티에서도 비슷하게 활용할 수 있도록 구현한 내용으로<br>
에디터에서 inspector 조작만으로도 컴포넌트내에 기능(클래스)를 설정하고 활용할 수 있도록 하였습니다.<br>
해당 기능을 통해 개발에 미숙한 인원이라고 하더라도, 현재 존재하는 기능을 활용해 게임 오브젝트를 제작할 수 있게 되었습니다.


<!--![이미지]()-->

<br>

## 🎞 코드 

### 충돌 기능
| Script명 | 설명 |
|---|---|
|[CollisionInteraction.cs](./Collision/CollisionInteraction.cs)| Scriptable Object를 상속하는 추상 클래스로 Collisionable에 포함되어<br>기능을 담당하는 클래스 |
|[EffectApplyer.cs](./Collision/EffectApplyer.cs)| 충돌 시 자신이 가진 Effector Component를 실행 해 충돌 대상에게<br> 효과를 적용하는 스크립트 (ex. 아이템) |
|[HitSounding.cs](./Collision/HitSounding.cs)| 충돌 시 충돌 소리를 재생하는 스크립트 |
|[Print.cs](./Collision/Print.cs)| 테스트 용도로 충돌 시 Debug.Log를 남기는 스크립트|
|[SelfDestory.cs](./Collision/SelfDestroy.cs)| 충돌 시 자기 자신을 파괴하는 스크립트 |
|[Shaker.cs](./Collision/Shaker.cs)| 충돌 시 Material을 변경하여 충돌했음을 알리는 스크립트 |



### 아이템 기능
아이템의 경우 게임 오브젝트에 Effector Component를 포함하고<br>
Collisionable Component의 기능에 EffectApplyer를 포함하여 사용하도록 설정<br>
Effector를 통해 해당 대상에게 사용될 수 있도록 하였습니다.
| Script명 | 설명 |
|---|---|
|[Effector.cs](./Item/Effector.cs)| EffectApplyer와 함께 쓰이며 EffectApplyer의 호출에 따라 ItemFunction들을 실행시키는 스크립트 |
|[ItemFunction.cs](./Item/ItemFunction.cs)| 아이템 기능의 추상메소드를 가지고 있는 추상 클래스 스크립트|
|[BallMultiply.cs](./Item/BallMultiply.cs)| 가지고 있는 무기의 개수를 2배로 늘려주는 아이템 스크립트 |
|[HPHeal.cs](./Item/HPHeal.cs)| 유저의 체력을 일정 수치 올려주는 아이템 스크립트 |

<br>


## [⏮ 돌아가기](../../)
