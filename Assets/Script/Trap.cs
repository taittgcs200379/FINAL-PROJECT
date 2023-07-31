using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    
    private void OnCollisionEnter(Collision collision)
    {




        if (collision.gameObject.tag.Equals("Player"))
        {
            TakeDamage.GetDamage(damage);
        }
    }
}
