using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DefaultNamespace;
using DefaultNamespace.Common;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 보스의 대화연출을 위해 제작한 클래스
/// 실행 시 Time.timeScale=0으로 만들어 놓고, 일정 시간마다 한 글자씩 출력해주는 클래스
/// Queue방식을 활용해 메세지를 출력한다.
/// 
/// </summary>
public class DialogTyper : MonoBehaviour
{
    [SerializeField] public float typeSpeed=0.5f;
    [SerializeField] private float typeEndedWaitTime=2;
    [SerializeField] private AudioClip[] typeSound;

    private Queue<string> printQueue;
    //잦은 string의 조합에 따라 StringBuilder 활용
    private StringBuilder sb;
    private TMP_Text dialogText;

    public bool isSbWriting { get; private set; } = false;

    private WaitUntil isUpToZeroQueue
    private void Awake()
    {
        dialogText = GetComponentInChildren<TMP_Text>();
        printQueue = new Queue<string>();
        sb = new StringBuilder(100);
        isUpToZeroQueue =  new WaitUntil(() => printQueue.Count > 0);
    }

    private void Start()
    {
        StartCoroutine(TypeQueue());
    }
    
    //string을 queue에 누적시킬 때 사용
    public void Enqueue(string typeString)
    {
        printQueue.Enqueue(typeString);
        isSbWriting = true;
    }

    //string을 바로 출력해야할 때 사용
    public void WriteNow(string nowString)
    {
        StartCoroutine(WriteNowCoroutine(nowString));
    }

    // queue에 있는 string을 한 줄 씩 출력 명령을 내리는 코루틴 함수
    //시스템이 실행되면 실행대기상태에 들어감
    // isUpToZeroQueue가 true가 될때 다시 반복문을 돌림
    private IEnumerator TypeQueue()
    {
        while (true)
        {
            while (printQueue.Count > 0)
            {
                isSbWriting = true;
                string typeString = printQueue.Peek();
                yield return StartCoroutine(TypePrint(typeString));
                printQueue.Dequeue();
            }
            isSbWriting = false;
            yield return isUpToZeroQueue;
        }
    }
    
    // 입력된 string을 한글자 씩 더해 dialogText에(TMP_Text) 출력시키는 코루틴 함수
    private IEnumerator TypePrint(string typeString)
    {
        foreach (char str in typeString)
        {
            sb.Append(str);
            dialogText.text = sb.ToString();
            if (str != ' ')
            {
                int idx = Random.Range(0, typeSound.Length);
                if(GameManager.Instance)
                    GameManager.Instance.PlaySFX(typeSound[idx], transform.position);
            }

            yield return CoroutineTime.GetWaitForSecondsRealtime(typeSpeed);
        }
        sb.Clear();
        yield return CoroutineTime.GetWaitForSecondsRealtime(typeEndedWaitTime);
        dialogText.text = "";
        
    }
    
    private IEnumerator WriteNowCoroutine(string typeString)
    {
        dialogText.text = typeString;
        yield return CoroutineTime.GetWaitForSecondsRealtime(typeEndedWaitTime);
        dialogText.text = "";
    }
}
