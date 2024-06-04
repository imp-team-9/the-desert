using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SunController : MonoBehaviour
{
    private float day = 2f;
    private float night = 10f;

    private bool isDay = true;
    private int dayCount = 1;
    [SerializeField] private TMP_Text dayCountText;
    [SerializeField] private AudioSource dayBell;

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
            if (!isDay)
            {
                isDay = true;
                dayBell.Play();
                dayCount += 1;
                dayCountText.text = "Day " + dayCount;
            }
        } else {
            isDay = false;
        }

        transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }

    public bool IsDay()
    {
        return transform.position.y >= -1.4;
    }
}
