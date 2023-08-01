using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class grillBehavior : MonoBehaviour
{
    public Slider slider;

    int indexOfGrillItems;

    bool canInteract;

    GameObject grillItem;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            grillItem.gameObject.GetComponent<XRGrabInteractable>().enabled = true;
            if (Time.time - timer >= 10)
            {
                timer = 0;
                canInteract = false;
                Destroy(grillItem);
            }
            else
                slider.value = (Time.time - timer) / 10;
        }

        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
            indexOfGrillItems = 0;
        else
        {
            timer = Time.time;
            grillItem = other.gameObject;
            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            other.gameObject.transform.position = new Vector3(-2, 0.9f, -1.8f);
            StartCoroutine(grillCoolDown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
            indexOfGrillItems = 0;
        else
        {
            if (Time.time - timer < 4.5)
                other.gameObject.GetComponent<hotDogFood>().underCooked = true;
            else if (Time.time - timer > 5.5 && Time.time - timer < 10)
                other.gameObject.GetComponent<hotDogFood>().overCooked = true;
            else
                other.gameObject.GetComponent<hotDogFood>().cookedProperly = true;
        }
    }

    IEnumerator grillCoolDown()
    {
        yield return new WaitForSeconds(2);
        canInteract = true;
    }

}
