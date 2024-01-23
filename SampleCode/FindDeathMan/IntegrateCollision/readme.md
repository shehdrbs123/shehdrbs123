# 🔎 충돌 처리 Component 구현

추상클래스를 활용 해 Component의 기능 중 충돌기능을 통합하여 **플레이어, 적, 아이템, 총알 등 <br>의 충돌기능을 하나의 Component로 통합한 구조**에 관한 코드입니다. 


![이미지]()

<br>

## 🎞 코드 

| Script명 | 설명 |
|---|---|
|[Collisionable.cs](./Collisionable.cs)| 충돌 담당 Component로 충돌 발생, 종료 시 SerializeField에 포함된 CollisionInteraction에<br> 포함된 기능을 수행하는 클래스입니다.|
|[CollisionInteraction.cs](./CollisionInteraction.cs) | 충돌 시 기능을 담당하는 ScriptableObject입니다. |
|[Attack.cs](./Attack.cs)| CollisionInteraction을 구현해 상대를 공격하는 기능을 가진 기능 SO 입니다. |


## [⏮ 돌아가기](../../)
