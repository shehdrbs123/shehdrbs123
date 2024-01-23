# [Cheater] IMGUI를 이용한 Cheater

## 개요

다음은

## 결과 미리보기

### Cheater의 모습

![Untitled](Image/content1.png)

### 사용 예

| 시간 조정 | 보유 소지금 변경 |
|---|---|
|![제목 없는 동영상 - Clipchamp로 제작 (7).gif](Image/content2.gif)| ![제목 없는 동영상 - Clipchamp로 제작 (5).gif](Image/content3.gif)|

<br>

- 요약 이미지
    
    ![기술 고민 - 동균.png](Image/content4.png)
    
<br>

## 🎞 코드 

| Script명 | 설명 |
|---|---|
|[Cheater.cs](./Cheater(#).cs)| IMGUI로 구현된 TodangTodang 데이터 조작 Cheater, 테스트에 활용하였습니다. |


## [⏮ 돌아가기](../../)

<!--
## ⚠️ **기술 도입 배경**

- 테스트가 필요한 위치까지 도달하는 데에 **시간이 많이 소요**
- ex) 뉴스 이벤트는 **날짜 기준의 이벤트**
    - 10, 20일에 발생하는 뉴스를 **테스트 하기 위해 10,20 일까지 게임 플레이**를 해야 했음(소요시간 多)

<br>
<br>

## 🤔 **기술 도입 과정**

- Inspector를 활용하는 방안
    - 게임 중 Hierachy에서 오브젝트를 선택하고, Inspector를 수정 해야 하는 불편함 존재
- 게임 중 Inspector를 건드리지 않고 조정할 수 있는 방법이 필요
    - Editor 기능 중 유니티의 **IMGUI**를 발견, 이용해보기로 결정

<br>
<br>

## 💡 **기술 도입으로 얻은 이점**

- IMGUI를 도입함으로 써 **인 게임 내에서 필요 시 즉각적으로 데이터를 수정 가능**
- 빠른 테스트 수행

<br>
<br>

## 구현 사항

### 데이터의 참조 방법

- Singleton 내 데이터는 **singleton instance를 이용해 데이터 가져오기**
- 그 외 객체는 **FindObjectWithTag를 이용하여 가져옴**
    - **Find, FindObjectOfType**은 Hierachy내 모든 오브젝트를 검색해 찾기 때문에 **사용 자재**
- 직접 데이터를 참조하는 것이 아닌 사본 참조
    - 직접 참조 시, **데이터가 입력이 끝나지 않았는데 적용되는 문제점**
    - 따라서 **사본을 만들어 참조를 하고, 적용 버튼을 누를 때 적용될 수 있도록 제작**

<br>
<br>

### OnGUI 코드 관리

- 반복되는 구조의 GUI 요소를 메소드화 시켜, 동일한 구조에 대해서 적용
    
    OnGUI Window에서 적용된 코드
    
    ```csharp
    dayChange = EditorGUILayout.Foldout(dayChange, "홈씬 상황변경");
    if(dayChange)
    {
        Button("아침",() => _gameManager.ChangeState(Enums.PlayerDayCycleState.StartStore));
        Button("매입전",() =>  _gameManager.ChangeState(Enums.PlayerDayCycleState.OpenMarket));
        Button("하루끝",() => _gameManager.ChangeState(Enums.PlayerDayCycleState.DayEnd));
    }
    ```
    
    메소드화 OnGUI
    
    ```csharp
    private void Button(string label, Action Applycallback)
    {
        if (GUILayout.Button(label))
        {
            callback?.Invoke();
        }
    }
    
    private void HorizontalTextFieldWithName(string title,ref string changeText)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(title,GUILayout.Width(boxSize.width*0.3f),GUILayout.MaxWidth(boxSize.width*0.3f));
        changeText=GUILayout.TextField(changeText,GUILayout.Width(boxSize.width*0.6f),GUILayout.MaxWidth(boxSize.width*0.6f));
        GUILayout.EndHorizontal();
    }
    
    private void HorizontalToggleWithName(string title, ref bool value)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(title,GUILayout.Width(boxSize.width*0.3f),GUILayout.MaxWidth(boxSize.width*0.3f));
        value=GUILayout.Toggle(value,title);
        GUILayout.EndHorizontal();
    }
    
    private void TextLineDraw(string label, ref int value)
    {
        string text = string.Empty;
        int tmp = 0;
        GUILayout.BeginHorizontal();
        GUILayout.Label(label);
        text =GUILayout.TextField(value.ToString());
        if (int.TryParse(text, out tmp))
            value = tmp;
        GUILayout.EndHorizontal();
    }
    
    private void InventoryInnerList<T>( List<T> list,int inventoryIdx ,Action<int> contentCallback) where T : BaseData
    {
        for (int detailInventoryIdx = 0; detailInventoryIdx < list.Count; ++detailInventoryIdx)
        {
            InventoryInnerFold[inventoryIdx][detailInventoryIdx + 1] = EditorGUILayout.Foldout(InventoryInnerFold[inventoryIdx][detailInventoryIdx + 1],
                list[detailInventoryIdx].name);
            GUILayout.BeginVertical(innerMargin);
            if (InventoryInnerFold[inventoryIdx][detailInventoryIdx + 1])
            {
                contentCallback?.Invoke(detailInventoryIdx);
            }
            GUILayout.EndVertical();
        }
    }
    ```


<br>
<br>

## 문제점

### 에디터 스크립트 사용으로 인한 **빌드 시 문제**

- UnityEditor는 Editor에서만 사용되는 라이브러리로, build오류를 발생시키는 주요 원인
- 시행착오
    - 처음에는 Editor 폴더에 넣는 방식을 써서 빌드 시 포함이 안되도록 수정
    - 그 결과 build 때마다 매번 폴더에 넣고 빼는 작업이 추가되고, 
    창 크기에 대한 Inspector를 계속 수정 해야하는 문제점 발생
- 해결
    - #if UNITY_EDITOR의 전처리 구문을 추가하여, Cheater가 빌드에 영향을 주지 않도록 구현
-->