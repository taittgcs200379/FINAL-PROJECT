using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallHealth : MonoBehaviour
{
    public int wallHP ;
    public int currHP;
 
    public int damage;


    public void Start()
    {
        
        currHP = wallHP;



    }
    public void Update()
    {




    }
    public void GetDamage(int damage)
    {
        currHP -= damage;
        
        if (currHP <= 0)
        {
            DestroyWall();

        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy Bullet"))
        {
            GetDamage(damage);
        }
    }
    private void DestroyWall()
    {
        Destroy(gameObject);
    }

}
