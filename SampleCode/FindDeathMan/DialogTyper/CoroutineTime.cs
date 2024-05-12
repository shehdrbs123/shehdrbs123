using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 제작자 : 노동균
/// Coroutine에 사용될 WaitForSeconds, WaitForSecondsRealtime의 클래스를 캐싱 해주는 static class
/// </summary>
public static class CoroutineTime
{
    private static Dictionary<float, WaitForSecondsRealtime> realtimePool = new Dictionary<float, WaitForSecondsRealtime>();
    private static Dictionary<float, WaitForSeconds> timePool = new Dictionary<float, WaitForSeconds>();

    public static WaitForSecondsRealtime GetWaitForSecondsRealtime(float time)
    {
        WaitForSecondsRealtime seconds;
        if (!realtimePool.TryGetValue(time, out seconds))
        {
            seconds = new WaitForSecondsRealtime(time);
            realtimePool.Add(seconds);
        }

        return seconds;
    }
    
    public static WaitForSeconds GetWaitForSeconds(float time)
    {
        WaitForSeconds seconds;
        if (!timePool.TryGetValue(time, out seconds))
        {
            seconds = new WaitForSeconds(time);
            timePool.Add(seconds);
        }

        return seconds;
    }
}
