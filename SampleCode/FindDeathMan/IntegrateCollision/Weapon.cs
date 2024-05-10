using System;
using UnityEngine;


namespace DefaultNamespace.Data
{
    [RequireComponent(typeof(Collisionable),typeof(AutoMover),typeof(PooledObject))]
    public class Weapon: MonoBehaviour
    {
        [SerializeField] private int _damage;
        public string owner="Player";
        public int Damage
        {
            get { return _damage;}
            private set { _damage = value; }
        }

        public void OnEnable()
        {
            if (gameObject.layer == LayerMask.NameToLayer("UserWeapon"))
            {
                GameManager gameManager = GameManager.Instance;
                if(gameManager)
                {
                    gameManager.AddWeapon(gameObject);
                }   
            }
        }

        public void OnDisable()
        {
            try
            {
                if (!GameManager.isApplicationExit || gameObject.layer == LayerMask.NameToLayer("UserWeapon"))
                {
                    GameManager gameManager = GameManager.Instance;
                    if (gameManager != null) 
                    {
                        gameManager.RemoveWeapon(gameObject);
                        if (owner == "player")
                        {
                            gameManager.ballCount -= 1;
                        }
                    }
                    else
                        Destroy(gameObject);                
                }
            }
            catch(Exception e)
            {
                
            }
           
        }
    }
}