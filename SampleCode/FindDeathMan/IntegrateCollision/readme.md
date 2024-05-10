# 🔎 충돌처리 통합 Component 구현

벽돌깨기의 게임의 가장 중심이 되는 기능 중 하나인 충돌을 하나의 Component로 통합하였고
Command 패턴을 활용해 기능을 분리하여, 기능을 아이템, 무기에 따라 다르게 가져갈 수 있도록 구성하였습니다.



## 충돌 Component Diagram
![이미지](/Image/FindDeathMan/CollisionDiagram.png)


<br>

## 🎞 코드 

| Script명 | 설명 |
|---|---|
|[Collisionable.cs](./Collisionable.cs)| 충돌처리 통합 Component로 충돌 발생, 종료 시 SerializeField에 포함된 CollisionInteraction에<br> 포함된 기능을 수행하는 클래스입니다.|
|[CollisionInteraction.cs](./CollisionInteraction.cs) | 충돌 시 기능을 담당하는 Scriptable Object입니다. |
|[Attack.cs](./Attack.cs)| CollisionInteraction을 구현해 상대를 공격하는 기능을 가진 기능 SO 입니다. |
|[Weapon.cs](./)| Attack시 Attack의 데미지 정보를 보유하고 있는 Component <br> Attack 기능이 포함될때 자동으로 추가된다.
<br>

## 기술 도입 배경

- 개발에 미숙한 인원과 8일이라는 짧은 기간 내 프로토 타입을 뽑아내기 위한 방법이 필요하였음
- 벽돌 게임 특성 상 여러 상황의 충돌이 발생할 것으로 예측
- 비슷한 코드/행위가 반복 될 것으로 보이고, 기능을 통합하여 ScriptableObject처럼 Inspector에서 쉽게 조정이 가능하다면 팀 개발에 유용할 것이라고 판단

## 기술의 적용
- CollisionInteraction 추상 클래스를 설계(ScriptableObject)
- CollisionInteraction 파생 클래스에서 기능을 구현
- 구현한 ScriptableObject 클래스들을 에셋으로 생성
- Command 패턴을 응용해 Collisionable에서 배열로 CollisionInteraction을 포함
- SerializeField로 필요한 기능을 inspector에서 연결
- 충돌 시 기능을 전부 실행

## 성과
- 같은 ScriptableObject를 여러 오브젝트에서 사용할 수 있어 **메모리 절약 가능**
- 변수로 써 포함되기에 Component를 포함할 때에 비해 **게임오브젝트의 볼륨이 감소**
- 기능을 레고처럼 조립할 수 있어서 **기능 확장/삭제가 편리**

## 문제점
### 충돌 필터링 방법
![CollisionLayerMatrix](/Image/FindDeathMan/CollsionLayerMatrix.png)
- 

### 공격과 같은 추가 데이터의 사용 애로
![]()

### Coroutine 사용 불가
![]()

## [⏮ 돌아가기](../../)
