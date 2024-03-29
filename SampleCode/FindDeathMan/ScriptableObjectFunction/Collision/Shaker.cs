using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Data.Functions;
using DefaultNamespace;
using DefaultNamespace.Common;
using UnityEngine;

[CreateAssetMenu(fileName = "Shaker", menuName = "Scriptable/CollisionInteraction/Shaker",order = 2)]
public class Shaker : CollisionInteraction
{
    public override void EnterCollsion(GameObject Owner, GameObject target)
    {
        Health health = target.GetComponent<Health>();
        if (health)
        {
            SpriteRenderer renderer = target.GetComponentInChildren<SpriteRenderer>();
#if UNITY_EDITOR
            Debug.Assert(renderer,"자식내에 컴포넌트 할당 필요 : renderer ");
#endif
            renderer.color = Color.red;
            health.HitRecoveryColor(ColorReturn,target);            
        }
    }

    public override void ExitCollsion(GameObject who, GameObject target)
    {
       
    }

    private IEnumerator ColorReturn(object target)
    {
        yield return CoroutineTime.GetWaitForSeconds(0.5f);
        GameObject gameObjectTarget = target as GameObject;
        SpriteRenderer renderer = gameObjectTarget.GetComponentInChildren<SpriteRenderer>();
        renderer.color = Color.white;
    }
}
