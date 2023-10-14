using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject box;
    public float radius = 1f;
    private void OnCollisionEnter(Collision collision)
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag.Equals("Bullet"))
            {
                DestroyBox();
            }

            

        }
    }
    private void DestroyBox()
    {
        Destroy(gameObject);
    }
}
