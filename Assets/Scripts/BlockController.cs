using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
        Debug.Log("Scaling to " + ratio);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void TurnOffSockets()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<XRSocketInteractor>().enabled = false;
        }
    }
    
    public void TurnOnSockets()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<XRSocketInteractor>().enabled = true;
        }
    }
}
