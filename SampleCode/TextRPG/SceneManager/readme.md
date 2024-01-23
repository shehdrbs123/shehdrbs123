# 🔎 DialogTyper

Coroutine과 Queue를 이용해 string을 한글자 씩 뽑아서 표기해주는 UI에 관한 내용입니다.


![이미지]()

<br>

## 🎞 코드 

| Script명 | 설명 |
|---|---|
|[DialogTyper.cs](./DialogTyper.cs) | 대화기능을 수행할 때 한 글자 씩 뽑아주는 기능을 하는 클래스<br>시작 시 자동으로 Coroutine을 수행하며, Queue의 개수를 조건으로 대기하고<br>Queue에 데이터가 들어오면 자동으로 대화 기능을 수행합니다. |
|[Scenario.cs](./Scenario.cs)|게임이 끝나고 엔딩 시의 대화 스크립트, DialogTyper가 적용된 스크립트 입니다.|


## [⏮ 돌아가기](../../)
