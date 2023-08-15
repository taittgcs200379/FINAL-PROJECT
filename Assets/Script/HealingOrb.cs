using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrb : MonoBehaviour
{
    public int regain;
    public float radius = 1f;
    public GameObject Orb;
    public TakeDamage takeDamage;
    private void OnCollisionEnter(Collision collision)
    {


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag.Equals ("Player"))
            {
                takeDamage.Heal(regain);
                
                Invoke(nameof(DestroyOrb),0.001f);
            }
        }
      

    }
    private void DestroyOrb()
    {
        Destroy(gameObject);
    }
}
