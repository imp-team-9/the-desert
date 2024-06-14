using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]
    private GameObject stoneBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


      void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Pickaxe"))
    {
       
        Vector3 spawnPosition = other.ClosestPoint(transform.position);
          Vector3 collisionDirection = (transform.position - other.transform.position).normalized;
        Vector3 spawnOffset = collisionDirection * 1f;

        
        Instantiate(stoneBlock, spawnPosition - spawnOffset, Quaternion.identity);
       
        
        
        
    }
}
}
