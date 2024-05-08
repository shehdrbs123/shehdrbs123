using System;
using UnityEngine;

namespace Data.Functions
{
    public abstract class CollisionInteraction : ScriptableObject
    {
        public abstract void EnterCollsion(GameObject Owner,GameObject target);
        public abstract void ExitCollsion(GameObject Owner,GameObject target);
        public virtual void AddRequireComponent(GameObject Owner)
        {
        
        }

        public virtual Component GetRemoveComponent(GameObject Owner)
        {
            return null;
        }
    }
}