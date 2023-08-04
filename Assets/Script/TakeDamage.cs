using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class TakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerHP = 100;
    public static int currHP;
    
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