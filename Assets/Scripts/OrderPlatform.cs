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

            //delete below code when testing in vr because you are gonna press the bell
            //Debug.Log("Take order was called");
            //currentCustomer.GetComponent<Customer>().TakeOrder();
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
