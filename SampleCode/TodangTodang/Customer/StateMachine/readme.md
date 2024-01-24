# 🔎 Customer

다음은 Customer의 상태머신에 관련된 코드 모음입니다.

<!--
## 🕵️‍♀️ 간략 설명
![이미지]() -->


<br>

## 🎞 코드 

| Script명 | 설명 |
|---|---|
|[ICusomterState.cs](./ICustomerState.cs) | 손님 상태에 필요한 기능을 정리한 Interface |
|[CustomerStateMachine.cs](./CustomerStateMachine.cs)| 손님의 상태를 관리, 변경을 해주는 클래스 |
|[CustomerBaseState.cs](./CustomerStates/CustomerBaseState.cs)| 손님의 상태의 기본이 되는 클래스 |
|[CustomerFailState.cs](./CustomerStates/CustomerFailState.cs)| 손님이 음식에 만족하지 못했을 때의 상태 클래스 |
|[CustomerSuccessState.cs](./CustomerStates/CustomerSuccessState.cs)| 손님이 음식에 만족했을 때의 상태 클래스 |




## [⏮ 돌아가기](../../)
