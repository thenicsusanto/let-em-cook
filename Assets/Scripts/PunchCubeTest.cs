using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(other.CompareTag("rightHand") && player.GetComponent<Movement>().middle3Fingers && player.GetComponent<Movement>().indexFinger)
        {
            Vector3 vel = other.gameObject.GetComponent<Rigidbody>().velocity;
            if(vel.x != 0 || vel.z != 0 || vel.y != 0.1)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = (this.transform.position - other.transform.position) * 20;
            }
        }
    }
}
