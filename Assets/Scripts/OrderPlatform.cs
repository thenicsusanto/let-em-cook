using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPlatform : MonoBehaviour
{
    private bool takeOrder;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Customer"))
        {
            takeOrder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            takeOrder = false;
        }
    }
}
