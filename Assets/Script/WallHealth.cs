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
    private void DestroyWall()
    {
        Destroy(gameObject);
    }

}
