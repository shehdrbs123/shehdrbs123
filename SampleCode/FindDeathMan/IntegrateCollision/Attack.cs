using System.Collections;
using System.Collections.Generic;
using Data.Functions;
using DefaultNamespace.Data;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable/CollisionInteraction/Attack",order = 2)]
public class Attack : CollisionInteraction
{
    
    public override void EnterCollsion(GameObject Owner, GameObject target)
    {
        if(Owner.TryGetComponent(out Weapon weapon) && )LayerMask.NameToLayer(weapon.owner) != target.layer 
        {
            if (target.TryGetComponent(out Health health))
                health.AddHealth(weapon.Damage);
        }
    }

    public override void ExitCollsion(GameObject who, GameObject target)
    {
        
    }
}

