using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketControl : MonoBehaviour
{

    public LayerMask Block;

    public void DisableSocketInChildren()
    {
        foreach (Transform child in transform)
        {
            XRSocketInteractor Socket = child.GetComponent<XRSocketInteractor>();
            Collider collider = child.GetComponent<SphereCollider>();

            if (Socket != null)
            {
                Socket.enabled = false;
                collider.enabled = false;
            }
        }

    }
    public void EnableSocketInChildren()
    {
        foreach (Transform child in transform)
        {
            XRSocketInteractor Socket = child.GetComponent<XRSocketInteractor>();
            Collider collider = child.GetComponent<SphereCollider>();
            if (Socket != null)
            {
                Socket.enabled = true;
                collider.enabled = true;
            }
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 0.01f,Block);
            if(hitColliders.Length > 0 && Socket.hasSelection == false)
            {
                Socket.enabled = false;
            }


        }
    }

   
}
