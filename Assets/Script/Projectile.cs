using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public int damage;
    public EnemyAi ai;
    private void OnCollisionEnter(Collision collision)
    {

        
        

        if (collision.gameObject.tag.Equals("Player"))
        {
            TakeDamage.GetDamage(damage);
        }
    }
}
