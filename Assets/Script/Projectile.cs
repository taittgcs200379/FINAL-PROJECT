using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public int damage;
    public EnemyAi ai;
    public TakeDamage takeDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            takeDamage.GetDamage(damage);
        }
    }
}
