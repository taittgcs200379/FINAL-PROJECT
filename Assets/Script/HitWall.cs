using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWall : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    
    
    private void OnCollisionEnter(Collision collision, WallHealth wallHealth)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            wallHealth.GetDamage(damage);
        }
    }
}
