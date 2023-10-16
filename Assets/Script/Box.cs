using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
   
    
    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.tag.Equals("Bullet"))
            {
            Invoke(nameof(DestroyBox), 0.001f);
        }   
    }
    private void DestroyBox()
    {
        Destroy(gameObject);
    }

}
