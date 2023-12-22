using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;
using System.Runtime.CompilerServices;

public class TakeDamage : MonoBehaviour
{
    
    public int playerHP;
    public int currHP;
    public HealthBar healthBar;
    public static bool isGameover;
   
    

     public void Start()
    {
        isGameover = false;
        currHP = playerHP;
       
       
        
    }
     public void Update()
    {
        
        
        if (isGameover )
        {
          SceneManager.LoadScene("SampleScene");
         //player.transform.position = isRespawn;
            
        }
        
        
        
    }
    public void GetDamage(int damage)
    {
        currHP -=damage;
        healthBar.SetHealth(currHP);
        
        if (currHP <= 0 )
        {
            isGameover = true;
           
        }
       
        
        
    }
    public  void Heal(int amount)
    {
        currHP += amount;
        healthBar.SetHealth(currHP);
        if (currHP > playerHP) 
        {
            currHP = playerHP;
        }
        
    }

    


}