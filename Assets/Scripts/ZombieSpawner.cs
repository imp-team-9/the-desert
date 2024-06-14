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
   [SerializeField]
   int spawnNumber;
   [SerializeField]
   private float mapSize;
   [SerializeField]
   private float shelterSize;

    void Start()
    {
        sunController = light.GetComponent<SunController>();
         spawnPoint = new Vector3();
        spawned = true;
        
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
       
        spawnPoint.y=0.1f;
        do{
            spawnPoint.x=Random.Range(mapSize*-1.0f,mapSize);
        }while (spawnPoint.x >= shelterSize*-1.0f && spawnPoint.x <= shelterSize);
        
        do{
            spawnPoint.z=Random.Range(mapSize*-1.0f,mapSize);
        }while(spawnPoint.z >= shelterSize*-1.0f && spawnPoint.z <= shelterSize);

        return spawnPoint;
     }
   

}
