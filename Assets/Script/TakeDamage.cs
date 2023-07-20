using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
public class TakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerHP = 100;
    public static int currHP;
    public TextMeshProUGUI playerHPText;
    
    public static bool isGameover;
   
    

     public void Start()
    {
        isGameover = false;
        currHP = playerHP;
       
    }
     public void Update()
    {
        playerHPText.text = "health:" + currHP;
        
        if (isGameover )
        {
          SceneManager.LoadScene("SampleScene");
          
        }
        
        
    }
    public static void GetDamage(int damage)
    {
        currHP -=damage;
        if (currHP <= 0 )
        {
            isGameover = true;
            
        }
        
        
    }
    public static void Heal(int amount)
    {
        currHP += amount;
        if(currHP > playerHP) 
        {
            currHP = playerHP;
        }
        
    }
    
}