using Data.Functions;
using DefaultNamespace.Data;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Collisionable : PooledObject
{
    [SerializeField] private CollisionInteraction[] Interactions;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (var interaction in Interactions)
        {
            interaction.EnterCollsion(gameObject, other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        foreach (var interaction in Interactions)
        {
            interaction.ExitCollsion(gameObject,other.gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var interaction in Interactions)
        {
            interaction.EnterCollsion(gameObject,other.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (var interaction in Interactions)
        {
            interaction.ExitCollsion(gameObject,other.gameObject);
        }
    }
}
