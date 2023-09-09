using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public int wallHP;
    public int currentwallHP;
    public int lostHP;
    public float radius = 1f;
    // Start is called before the first frame update
    void Start()
    {
        wallHP = currentwallHP;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag.Equals("Enemy Bullet"))
            {
                currentwallHP -= lostHP;
            }
           
        }

    }
    private void wallExplore()
    {
        if(currentwallHP <= 0) 
        {
            Invoke(nameof(Destroywall), 0.001f);
        }
    }

    private void Destroywall()
    {
        Destroy(gameObject);
    }
}
