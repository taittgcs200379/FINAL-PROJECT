using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {

            if (collision.gameObject.tag.Equals("Box"))
            {
                DestroyBox();
            }
    }
    private void DestroyBox()
    {
        Destroy(gameObject);
    }
}
