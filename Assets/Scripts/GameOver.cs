using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameoverText;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider is BoxCollider)
        {
        
            if (collision.collider.CompareTag("Zombie"))
          {
             
            gameoverText.SetActive(true);
             Invoke("moveToIntroScene", 3f);
                
          }
        
        }
    }


   private void moveToIntroScene(){
        SceneManager.LoadScene("Intro");
   }
}
