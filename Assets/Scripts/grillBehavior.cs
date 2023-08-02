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
        /*if (canInteract)
        {
            Debug.Log(Time.time - timer);
            grillItem.gameObject.GetComponent<XRGrabInteractable>().enabled = true;
            if (Time.time - timer >= 10)
            {
                timer = 0;
                canInteract = false;
                Destroy(grillItem);
            }
            else
                slider.value = (Time.time - timer) * 10;
        }*/




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
            indexOfGrillItems = 0;
        else
        {
            timer = (float)Time.time;
            grillItem = other.gameObject;
            
            other.gameObject.transform.position = new Vector3(-1.247f, 0.872f, 0.316f);

            other.gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(0, 90, 0));

            canInteract = true;
            StartCoroutine(StartTimer(10f));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
            indexOfGrillItems = 0;
        else
        {
            Debug.Log("Left collider " + other.gameObject.name);
            if (Time.time - timer < 4.5)
                other.gameObject.GetComponent<hotDogFood>().underCooked = true;
            else if (Time.time - timer > 5.5 && Time.time - timer < 10)
                other.gameObject.GetComponent<hotDogFood>().overCooked = true;
            else
                other.gameObject.GetComponent<hotDogFood>().cookedProperly = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            canInteract = false;
        }
        
    }

    IEnumerator StartTimer(float sec)
    {
        float timer = 0;
        while (timer < sec && canInteract) 
        { 
            slider.value = timer / sec;
            timer += Time.deltaTime;
            yield return null;
        }
        

    }
}
