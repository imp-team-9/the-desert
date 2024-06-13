using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            if (Vector3.Distance(other.transform.position, transform.position) <= 1)
            {
                gameObject.SetActive(false);
            }
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            if (Vector3.Distance(other.transform.position, transform.position) >= 1)
            {
                gameObject.SetActive(true);
            }
        }


    }
}
