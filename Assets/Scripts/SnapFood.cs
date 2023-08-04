using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<hotDogFood>() != null && collider.gameObject != this.transform.parent)
        {
            Debug.Log("Collided with: " + collider.name);
            collider.GetComponent<XRGrabInteractable>().enabled = false;
            collider.GetComponent<Rigidbody>().useGravity = false;
            collider.GetComponent<Rigidbody>().isKinematic = true;
            collider.isTrigger = true;
            collider.transform.SetParent(transform.parent);
            collider.transform.localPosition = new Vector3(0, 1.25f, 0);

            collider.transform.localRotation = Quaternion.identity;
            collider.transform.localScale = Vector3.one;
        }
    }
}
