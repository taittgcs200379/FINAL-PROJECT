using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallHealth : MonoBehaviour
{
    public int wallHP ;
    public int currHP;
    public GameObject wall;
    public bool isGameover;
    public int damage;


    public void Start()
    {
        isGameover = false;
        currHP = wallHP;



    }
    public void Update()
    {


        if (isGameover)
        {
            DestroyWall();

        }



    }
    public void GetDamage(int damage)
    {
        currHP -= damage;
        
        if (currHP <= 0)
        {
            isGameover = true;

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
