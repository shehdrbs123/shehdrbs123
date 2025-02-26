## TodangTodang

## 개요 
<table>
<tr >
    <td width="50%">TodangTodang </td> 
</tr>
<tr >
    <td><image src="../../Image/todangtodang2.gif"/> </td>
</tr>
<tr >
    <td>Windows / Web / Android</td> 
</tr>
<tr >
    <td> 4인 / 2023.10.23 ~ 2023.12.15 (54일) </td>
</tr>
<tr >
    <td>C# / Unity 2022.3.2f1 / Rider 2023.1.2</td>
</tr>
<tr>
    <td>
        오버쿡드의 게임방식에 재료를 구매, 경영하는 컨텐츠를 더해 만든 싱글 플레이 타이쿤 게임
    </td>
</tr>
<tr>
    <td>
        - SO 데이터 컨테이너 및 Save/Load/암호화/무결성검증 기능이 있는 DataManager 구현<br>
        - IMGUI를 이용해 빠른 테스트를 하기 위한 Cheater 개발<br>
        - ScriptableObject, EditorScripting를 이용한 DDP를 구현, 손님 외관 데이터 확장성 재고<br>
        - 크로스 플랫폼 빌드를 위한 전처리 및 빌드, 게시 (Web, PC, 모바일)<br>
        - 손님 생명주기 설계/상태머신을 이용한 손님 기능구현<br>
        - 게임의 기획 분석을 위한 Firebase Analytics 연동<br>
    </td>
</tr>
<tr>
    <td>
        프로그램 다운로드 <br>
        <a href="https://play.google.com/store/apps/details?id=com.twelveganzi.todangtodang&hl=ko-KR">안드로이드</a> <br>
        <a href="https://twelveganzi.itch.io/todangtodang">itch.io (WEB)</a> (주의) web최적화가 되어있지 않음 
    </td>
</tr>
<tr>
    <td>
        <a href="https://github.com/shehdrbs123/shehdrbs123/tree/main/SampleCode/TodangTodang">샘플코드</a>
    </td>
</tr>
</table>


## 코드 샘플
|목차|
|---|
|[옵저버패턴 활용 데이터 저장, 암호화/무결성 검증<br> 기능이 있는 DataManager](./DataManager)|
|[빠른 테스트, 적용을 위한 IMGUI Cheater](./Cheater/)|
|[SO와 EditorScript를 활용한 손님 외관 설정](./Customer/AppearanceEditorScript/)|
|[상태머신을 이용한 손님](./Customer/StateMachine/)|


## [⏮ 돌아가기](../)