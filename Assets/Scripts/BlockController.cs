using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BlockController : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }





    public void ScaleTo(float scaleFactor = 0.5f)
    {
        Debug.Log("ScaleTo: " + scaleFactor);
        if(scaleFactor == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1)*scaleFactor;
        }
    }

   
}
