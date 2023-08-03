using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryAttack : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];

        Vector3 vel = (player.transform.position - transform.position).normalized;

        Quaternion newRot = Quaternion.LookRotation(vel);
        transform.rotation = newRot;
        transform.eulerAngles += new Vector3(0, 90, 0);


        vel *= 1f;
        Debug.Log(vel);
        rb = GetComponent<Rigidbody>();
        rb.velocity = (vel);


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = (player.transform.position - transform.position).normalized;
        rb.velocity = vel;
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 0.1f &&
            Mathf.Abs(player.transform.position.z - transform.position.z) < 0.1f)
        {
            player.GetComponent<Movement>().health -= 20;
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("DOG"))
        {
            Destroy(this.gameObject);
        }
    }
}
