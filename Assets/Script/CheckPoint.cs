using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject point;
    
    Vector3 spawnpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            spawnpoint= point.transform.position;
            Destroy(point);
        }
    }
}
