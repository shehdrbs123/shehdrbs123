# 🔎 기능 ScriptableObject

언리얼의 클래스 레퍼런스 기능을 유니티에 적용해 기능의 추가/삭제가 용이한 구조를 만들어 보고 싶었습니다.
그래서 ScriptableObject의 에셋화 기능을 이용하여 구현한 기능 ScriptableObject의 코드입니다.


![이미지]()

<br>

## 🎞 코드 

### 충돌
| Script명 | 설명 |
|---|---|
|[CollisionInteraction.cs](./Destoryer.cs)| 기능을 담은 추상 클래스로 Collisionable과 함께 충돌 시 기능에 대한 추상 메소드를 포함하는 클래스 |
|[EffectApplyer.cs](./EffectApplyer.cs)|  |
|[HitSounding.cs](./HitSounding.cs)| 충돌 시 충돌 소리를 재생하는 기능SO 클래스 |
|[Print.cs](./Print.cs)| 테스트 용도로 충돌 시 Debug.Log를 남기는 SO 클래스 |
|[SelfDestory.cs](./SelfDestory.cs)| 충돌 시 자기 자신을 파괴하는 SO 클래스 |
|[Shaker.cs](./Shaker.cs)| 충돌 시 Material의 |

### 아이템
| Script명 | 설명 |
|---|---|
|[ItemFunction.cs](./ItemFunction.cs)|  |
|[BallMultiply.cs](./BallMultiply.cs)|  |
|[HPHeal.cs](./HPHeal.cs)|  |

## [⏮ 돌아가기](../../)
