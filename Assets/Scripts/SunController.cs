using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    private float day = 2f;
    private float night = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        float speed = night;
        if (transform.position.y >= -1.4)
        {
            speed = day;
        }

        transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }

    public bool isDay()
    {
        return transform.position.y >= -1.4;
    }
}
