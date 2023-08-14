using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAmmo : MonoBehaviour
{
    public int bonus;
    public float radius = 1f;
    public GameObject Box;
    public GunSystem gun;
    private void OnCollisionEnter(Collision collision)
    {


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag.Equals("Player"))
            {
                gun.Bonus(bonus);
                // Destroy(collision.gameObject);
                Invoke(nameof(DestroyOrb), 0.001f);
            }
        }


    }
    private void DestroyOrb()
    {
        Destroy(gameObject);
    }
}
