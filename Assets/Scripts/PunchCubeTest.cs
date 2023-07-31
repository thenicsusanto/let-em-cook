using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PunchCubeTest : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("rightHand") && player.GetComponent<Movement>().middleThreeFingers && player.GetComponent<Movement>().indexFinger)
        {
            Vector3 vel = other.gameObject.GetComponent<Rigidbody>().velocity;
            if(vel.x != 0 || vel.z != 0 || vel.y != 0.1)
            {
                Debug.Log("worked");
                this.gameObject.GetComponent<Rigidbody>().velocity = (this.transform.position - other.transform.position) * 20;
                player.GetComponent<Movement>().middleThreeFingers = false;
                player.GetComponent<Movement>().indexFinger = false;
                other.gameObject.GetComponent<ActionBasedController>().SendHapticImpulse(0.1f, 0.1f);
            }
        }
    }
}
