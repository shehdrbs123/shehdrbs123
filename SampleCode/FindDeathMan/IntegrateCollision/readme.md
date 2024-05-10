# 🔎 충돌처리 통합 Component 구현

벽돌깨기의 게임의 가장 중심이 되는 기능 중 하나인 충돌을 하나의 Component로 통합하였고
Command 패턴을 활용해 기능을 분리하여, 기능을 아이템, 무기에 따라 다르게 가져갈 수 있도록 구성하였습니다.



## 충돌 Component Diagram
![이미지](/Image/FindDeathMan/CollisionDiagram.png)


<br>

## 🎞 코드 

| Script명 | 설명 |
|---|---|
|[Collisionable.cs](./Collisionable.cs)| 충돌처리 통합 Component로 충돌 발생, 종료 시 SerializeField에 포함된 CollisionInteraction에<br> 포함된 기능을 수행하는 클래스입니다. <br> 기능을 추가할 경우 자동으로 추가 Component를 추가/삭제하는 기능도 포함되어 있습니다.|
|[CollisionInteraction.cs](./CollisionInteraction.cs) | 충돌 시 기능을 담당하는 Scriptable Object입니다. |
|[Attack.cs](./Attack.cs)| CollisionInteraction을 구현해 상대를 공격하는 기능을 가진 기능 SO 입니다. |
|[Weapon.cs](./Weapon.cs)| Attack시 Attack의 데미지 정보를 보유하고 있는 Component <br> Attack 기능이 포함될때 자동으로 추가된다.
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
- 기능을 레고처럼 조립할 수 있어서 **기능 확장/삭제가 편리**
- 같은 ScriptableObject를 여러 오브젝트에서 사용할 수 있어 **메모리 절약 가능**
- 변수로 써 포함되기에 Component를 포함할 때에 비해 **게임오브젝트의 볼륨이 감소**


<br>

---

<br>

## 문제점 해결
### 충돌 필터링 방법
![CollisionLayerMatrix](/Image/FindDeathMan/CollsionLayerMatrix.png)
#### 충돌 오브젝트가 같은 Script를 사용하게 되어 충돌 대상을 지정하기 어려운 문제 발생
- Layer, 태그를 체크하기 위한 추가적인 구조나 로직을 고민해야 하는 문제<br>
- Layer, 태그를 직접 체크하는 방식은 일반화된 코드에서 적용하기 어려움<br>
- Collision Layer Matrix를 사용 시 자동으로 충돌 필터링이 가능


그래서 Collision Layer Matrix 적용해 EnemyWeapon, UserWeapon, Item, Monster 네 분류로 나누어 충돌 수행
#### 효과
- 코드에서 대상 체크를 하는 연산을 덜 해도 됨
- 유니티 물리 시스템 내에서 충돌 오브젝트끼리 자동으로 필터링이 이루어져 충돌 연산 최적화로 성능 향상

---

### 공격과 같은 추가 데이터의 사용 애로
![AdditionalData](/Image/FindDeathMan/AdditionalData.png)

#### 공격과 같이 무기별로 다른 데미지를 표현하기 위한 수단이 필요하였음.

- 에셋을 공격력 별로 만들어둔다.
- 추가 컴포넌트를 활용한다.

에셋별로 공격력을 따로 만들게 될 경우 이전 작업보다 복잡한 작업으로 진행될것으로 생각 됨.<br>
따라서 공격력 별로 따로 만들기 보다 추가 컴포넌트를 활용하는 방법을 선택함.

이때 기능별로 컴포넌트를 일일히 추가 해주어야하는 부분이 있었고
이것을 다음과 같이 자동으로 추가할 수 있도록 추가해줌

``` cs
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (preActions.Count != action.Length)
        {
            bool[] isAlived = new bool[preActions.Count];

            List<CollisionInteraction> newNeedComponent = new List<CollisionInteraction>(10);
            //추가,삭제 Component Check
            for (int i = 0; i < action.Length; i++)
            {
                int idx = preActions.FindIndex(x => x == action[i]);
                if(idx == -1)
                    newNeedComponent.Add(action[i]);
                else
                {
                    isAlived[idx] = true;
                }
            }
            // Component 삭제
            int delCount = 0;
            for (int i = 0; i < isAlived.Length; i++)
            {
                if (!isAlived[i])
                {
                    Component component = preActions[i-delCount].GetRemoveComponent(gameObject);
                    UnityEditor.EditorApplication.delayCall += () => { DestroyImmediate(component,true); };
                    preActions.RemoveAt(i-delCount);
                    ++delCount;
                }
            }
            // Component 추가
            for (int i = 0; i < newNeedComponent.Count; i++)
            {
                newNeedComponent[i].AddRequireComponent(gameObject);
                preActions.Add(newNeedComponent[i]);
            }
        }
    }
#endif
```

### Coroutine 사용 불가
![](/Image/FindDeathMan/CoroutineProblem.png)

기능이 외부에서 구현되는 이유로, Coroutine를 이용해 비동기기능을 구현하기 어려운 점이 있었습니다.

가장 간단하게 대상이 되는 GameObject에 함수를 넘겨 실행 될 수 있도록 구현하였습니다.<br>
이때 전용 Component를 만드는 대신 종속관계에 있는 Component에서 비동기기능을 수행할 수 있도록 구성하였습니다.

그 이유는 현재 상황에서는 전용 Component를 만들만큼 비동기 기능을 많이 사용하지 않아서 필요하지 않아<br>
종속관계 있는 Component를 이용하는 방식을 활용하였습니다.

## [⏮ 돌아가기](../../)
