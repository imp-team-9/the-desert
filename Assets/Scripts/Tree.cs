using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private GameObject woodBlock;
    [SerializeField]
    private Transform pos;
    [SerializeField]
    private Transform pos2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Axe"))
        {
            Destroy(gameObject); 

            
            Instantiate(woodBlock, pos.position, Quaternion.identity);
            Instantiate(woodBlock, pos2.position , Quaternion.identity);
        }
        
    }
}
