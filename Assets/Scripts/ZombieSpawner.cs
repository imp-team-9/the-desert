using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    
  [SerializeField]
  private GameObject light;
  [SerializeField]
  private GameObject zombiePrefab;

  private SunController sunController;
   Vector3 spawnPoint;
   bool spawned;
   int spawnNumber;

    void Start()
    {
        sunController = light.GetComponent<SunController>();
         spawnPoint = new Vector3();
        spawned = true;
        spawnNumber=100;
    }

    // Update is called once per frame
    void Update()
    {
       if(sunController.IsDay()){
         spawned=false;
         foreach (Transform child in gameObject.transform)
         {
            Destroy(child.gameObject);
         }
       }

       if(!spawned&&!sunController.IsDay()){
         spawnZombie();
       }
       

    
    }

    private void  spawnZombie(){
     
             for(int i=0; i<spawnNumber; i++){
             Vector3 pos = GetRandomPosition();
             GameObject zombie = Instantiate(zombiePrefab,pos,Quaternion.identity);
             zombie.transform.SetParent(gameObject.transform);
            }  
             spawned=true;  
        
    }

     private Vector3 GetRandomPosition(){
       
        spawnPoint.y=-1.3f;
        do{
            spawnPoint.x=Random.Range(-250.0f,250.0f);
        }while (spawnPoint.x >= -25.0f && spawnPoint.x <= 25.0f);
        
        do{
            spawnPoint.z=Random.Range(-250.0f,250.0f);
        }while(spawnPoint.z >= -25.0f && spawnPoint.z <= 25.0f);

        return spawnPoint;
     }
   

}
