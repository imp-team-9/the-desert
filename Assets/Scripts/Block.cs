using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    public int Hp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp<=0){
            Destroy(gameObject);
        }
    }

    public void Attacked(){
        Hp--;
        Debug.Log("attacked, block HP:" + Hp);
    }


}
