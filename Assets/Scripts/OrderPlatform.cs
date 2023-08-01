using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPlatform : MonoBehaviour
{
    public bool takeOrder;
    public GameObject currentCustomer;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Customer"))
        {
            takeOrder = true;
            currentCustomer = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            takeOrder = false;
            currentCustomer = null;
        }
    }
}
