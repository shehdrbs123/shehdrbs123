# 🔎 방어시설 및 BuildManager

방어시설 및 건설 시스템인 BuildManager에 대한 코드입니다.


<!--![이미지]()-->

<br>

## 🎞 코드 

### 충돌 기능
| Script명 | 설명 |
|---|---|
|[BuildManager](./BuildManager.cs)| build기능을 담당하는 BuildManager 입니다. |
|[TurretAIBase.cs](./TurretAIBase.cs)| 방어시설의 기본이 되는 클래스, 기본적인 터렛의 움직임을 담당하는 코드입니다. |
|[TurretAICannon.cs](./TurretAICannon.cs)| TurretAIBase를 상속하고, 레이져포를 발사하는 방어시설 코드입니다. |
|[TurretAIMissle.cs](./TurretAIMissle.cs)| TurretAIBase를 상속하고, 다량의 반유도 미사일을 발사하는 방어시설 코드입니다. |
|[TurretAIThrower.cs](./TurretAIThrower.cs)| TurretAIBase를 상속하고, 투석기, 곡사포 방어시설 코드입니다. |
|[RangeDraw.cs](./TurretAIThrower.cs)| 각 방어시설의 범위를 설정하면 해당 범위를 표시해주는 컴포넌트의 코드 입니다. |


<br>

## [⏮ 돌아가기](../../)
