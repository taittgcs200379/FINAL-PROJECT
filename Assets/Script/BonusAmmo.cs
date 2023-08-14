using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    public int Bonus;
    public float radius = 1f;
    public GameObject AmmoBox;
    public GunSystem gun;
    private void OnCollisionEnter(Collision collision)
    {


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag.Equals("Player"))
            {
                gun.Bonus(Bonus);
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
