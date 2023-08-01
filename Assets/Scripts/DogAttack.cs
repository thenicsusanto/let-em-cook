using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];

        Vector3 vel = player.transform.position - transform.position;

        Quaternion newRot = Quaternion.LookRotation(vel);
        transform.rotation = newRot;
        transform.eulerAngles += new Vector3(0, 90, 0);


        vel *= 1f;
        Debug.Log(vel);
        GetComponent<Rigidbody>().velocity = (vel);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.x - transform.position.x) < 0.1f &&
            Mathf.Abs(player.transform.position.z - transform.position.z) < 0.1f)
        {
            player.GetComponent<Movement>().health -= 5;
            Destroy(this.gameObject);
        }

        //if (Time.time > 7)
            //Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("DOG"))
        {
            Destroy(this.gameObject);
        }
    }
}
