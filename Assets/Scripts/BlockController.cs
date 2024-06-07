using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleTo(float ratio)
    {
        Debug.Log("ScaleTo: " + ratio);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
